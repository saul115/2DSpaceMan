using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float walkingSpeed = 3f;
    public float jumpForce = 22f;


    Animator animator;
    Rigidbody2D rigidBody;
    SpriteRenderer spriteRender;

    Vector2 startPosition;
   

    const string STATE_ALIVE = "Alive";
    const string STATE_ON_THE_GROUND = "Ground";


    public LayerMask groundMask;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
        startPosition = this.transform.position;

        
    }


    //Method to Restart the Game
    public void RestartGame()
    {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, false);

        Invoke("RestartPosition", 0.1f);
    }

    public void RestartPosition()
    {
        this.transform.position = startPosition;
        this.rigidBody.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {

      
    }


    private void FixedUpdate()
    {
        animator.SetBool(STATE_ON_THE_GROUND, IsOnTheGround());


        if (GameManager.sharedInstance.currentState == GameState.inGame)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (rigidBody.velocity.x < walkingSpeed)
                {
                    rigidBody.velocity = new Vector2(walkingSpeed, rigidBody.velocity.y);

                    spriteRender.flipX = false;

                    transform.localScale = new Vector2(1, transform.localScale.y);
                }
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (rigidBody.velocity.x < walkingSpeed)
                {
                    rigidBody.velocity = new Vector2(walkingSpeed * -1, rigidBody.velocity.y);

                    spriteRender.flipX = true;

                    transform.localScale = new Vector2(1, transform.localScale.y);
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }


            
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

       


        Debug.DrawRay(this.transform.position, Vector2.down * 1.45f, Color.cyan);
    }


    void Jump()
    {
        if(IsOnTheGround())
        {
            rigidBody.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }
    }

    public bool IsOnTheGround()
    {
        if(Physics2D.Raycast(this.transform.position,Vector2.down,1.45f,groundMask))
        {
            
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Die()
    {
        this.animator.SetBool(STATE_ALIVE, false);
        GameManager.sharedInstance.GameOver();
    }


}

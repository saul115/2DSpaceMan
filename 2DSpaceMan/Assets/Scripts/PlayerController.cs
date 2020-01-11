using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float walkingSpeed = 3f;
    public float jumpForce = 15f;


    Animator animator;
    Rigidbody2D rigidBody;
    SpriteRenderer spriteRender;

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
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, false);
    }

    // Update is called once per frame
    void Update()
    {

      
    }


    private void FixedUpdate()
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


        animator.SetBool(STATE_ON_THE_GROUND, IsOnTheGround());


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




}

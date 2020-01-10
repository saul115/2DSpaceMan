using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float walkingSpeed = 3f;
    public float jumpForce = 30f;


    Animator animator;
    Rigidbody2D rigidbody;
    SpriteRenderer spriteRender;
    Physics2D physics;

    const string STATE_ALIVE = "isAlive";
    const string STATE_ON_THE_GROUND = "isOnTheGround";


    public LayerMask groundMask;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
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
       

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }


        Debug.DrawRay(this.transform.position, Vector2.down * 1.36f, Color.cyan);
    }


    void Jump()
    {
        if(onTheGround())
        {
            rigidbody.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }
    }

    bool onTheGround()
    {
        if(Physics2D.Raycast(this.transform.position,Vector2.down,1.36f,groundMask))
        {
            
            return true;
        }
        else
        {
            return false;
        }
    }




}

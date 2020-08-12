using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public static bool  isTouchObject;
    public LayerMask Object;
    public static Rigidbody2D rb;
    public static Collider2D coll;
    public static GameObject gameOb;
    public static bool doubleJump = false;
    public static GameObject human;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        
    }

    
    void Update()
    {
        
        isTouchObject = IsGrounded();

    }

    public static void DoJump(int jumpDirection)
    {
        // unset Kinematic cho Circle nếu không sẽ không nhảy được !!
        rb.isKinematic = false;

        // hoặc dùng gravityScale

        //rb.gravityScale = 1;
        //rb.mass = 0.1f;


        //gameOb.transform.SetParent(null);

        Debug.Log(isTouchObject);
        if ( isTouchObject)
        {
            
            rb.velocity = new Vector2(jumpDirection * 1.5f, 4f);
            doubleJump = true;
            
        }
        else if (doubleJump)
        {
            
            rb.velocity = new Vector2(jumpDirection * 1.5f, 4f);
            doubleJump = false;

        }
        //coll.isTrigger = true;
    }


    public bool IsGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
        
    }
    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    isTouchObject = true;
    //}
    //public void OnCollisionExit2D(Collision2D collision)
    //{
    //    isTouchObject = false;
    //}

}

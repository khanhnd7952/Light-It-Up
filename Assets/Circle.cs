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
    public GameObject jump;
    public GameObject bamTuong;
    public static int rotateDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        jump.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        bamTuong.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    
    void Update()
    {
        if ( isTouchObject)
        {
            // chuyển đổi trạng thái
            jump.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            bamTuong.gameObject.GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            // chuyển đổi trạng thái
            jump.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            bamTuong.gameObject.GetComponent<SpriteRenderer>().enabled = false;

            // rotate khi doublejump
            if (!doubleJump)
            {
                jump.transform.Rotate(new Vector3(0, 0, 1) * rotateDirection * 1000 * Time.deltaTime);
            }
        }

    }

    public static void DoJump(int jumpDirection)
    {
        // unset Kinematic cho Circle
        rb.isKinematic = false;

        

        
        if ( isTouchObject)
        {
            
            rb.velocity = new Vector2(jumpDirection * 1.5f, 4f);

            isTouchObject = false;

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
    // test github
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
        
    }

}

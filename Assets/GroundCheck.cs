using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : Circle
{
    public static bool isGrounded;

    private void Start()
    {
        JumpState();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // chuyển đổi trạng thái sang leo tường
        ClimbState(collider);

        if (collider.gameObject.name == "Solid")
        {
            // Chạm đất và cho phép doublejump
            DoubleJump = true;
            isGrounded = true;

            // Biến Hình
            Jump.GetComponent<SpriteRenderer>().color = collider.GetComponent<SpriteRenderer>().color;
            ClimbLeft.GetComponent<SpriteRenderer>().color = collider.GetComponent<SpriteRenderer>().color;
            ClimbRight.GetComponent<SpriteRenderer>().color = collider.GetComponent<SpriteRenderer>().color;

        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        // chuyển đổi trạng thái sang nhảy
        JumpState();

        if (collision.gameObject.name == "Solid")
        {
            Coll.isTrigger = false;  
        }

        isGrounded = false;
        
        
    }

    // trạng thái leo tường
    private void ClimbState(Collider2D collider)
    {
        if (collider.gameObject.tag == "Edge")
        {
            ClimbLeft.transform.rotation = collider.transform.rotation;
            ClimbRight.transform.rotation = collider.transform.rotation;
        }
        Jump.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        if (jumpDirection == 1)
        {
            ClimbLeft.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            ClimbRight.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        
    }
    // trạng thái nhảy
    private void JumpState()
    {
        Jump.transform.rotation = new Quaternion(0, 0, 0, 0);
        Jump.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        ClimbLeft.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        ClimbRight.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

}

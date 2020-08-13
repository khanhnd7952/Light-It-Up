using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    public static bool isGrounded;
    public GameObject circle;
    public GameObject jump;
    public GameObject climb;
    public Collider2D Coll;

    

    private void Start()
    {
        JumpState();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // chuyển đổi trạng thái sang leo tường
        ClimbState();

        if (collision.gameObject.name == "Full")
        {
            Circle.doubleJump = true;
            isGrounded = true;
            jump.GetComponent<SpriteRenderer>().color = collision.GetComponent<SpriteRenderer>().color;
            climb.GetComponent<SpriteRenderer>().color = collision.GetComponent<SpriteRenderer>().color;
            
        }

        if (collision.gameObject.tag == "Edge")
        {
            climb.transform.rotation = collision.transform.rotation;
        }

    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        // chuyển đổi trạng thái sang nhảy
        JumpState();

        if (collision.gameObject.name == "Full")
        {
            Coll.isTrigger = false;
            
        }

        jump.transform.rotation = new Quaternion(0, 0, 0, 0);
        isGrounded = false;
        
        
    }

    // trạng thái leo tường
    private void ClimbState()
    {
        jump.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        climb.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
    // trạng thái nhảy
    private void JumpState()
    {
        jump.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        climb.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

}

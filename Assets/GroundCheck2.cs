using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck2 : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    public bool isGrounded;

    public GameObject jump;
    public GameObject climb;
    public Collider2D Coll;

    private void Update()
    {
        //gameObject.GetComponent<Collider2D>().isTrigger = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // chuyển đổi trạng thái sang leo tường
        Climb();

        if (collision.gameObject.name == "Full")
        {
            Circle.doubleJump = true;
            Debug.Log("Enter");
            Circle.isTouchObject = true;
        }

        if (collision.gameObject.tag == "Edge")
        {
            climb.transform.rotation = collision.transform.rotation;
        }

    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        // chuyển đổi trạng thái sang nhảy
        Jump();

        if (collision.gameObject.name == "Full")
        {
            Coll.isTrigger = false;
            
        }

        jump.transform.rotation = new Quaternion(0, 0, 0, 0);

        Circle.isTouchObject = false;
        
    }


    private void Climb()
    {
        jump.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        climb.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
    private void Jump()
    {
        jump.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        climb.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

}

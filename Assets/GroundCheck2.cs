using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck2 : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    public bool isGrounded;

    public GameObject human;
    public GameObject bamTuong;
    public Collider2D Coll;

    private void Update()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = true;
    }


    //private void OnTriggerStay2D(Collider2D collider)
    //{

    //    isGrounded = collider != null && (((1 << collider.gameObject.layer) & platformLayerMask) != 0);

    //    if (collider.gameObject.tag == "Edge")
    //    {
    //        human.transform.rotation = collider.transform.rotation;
    //    }

    //}




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Full")
        {
            Circle.doubleJump = true;
            Debug.Log("Enter");
            Circle.isTouchObject = true;
        }

        if (collision.gameObject.tag == "Edge")
        {
            bamTuong.transform.rotation = collision.transform.rotation;
        }

    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Edge")
        //{
        //    Circle.isTrigger = false;
        //}
        if (collision.gameObject.name == "Full")
        {
            Coll.isTrigger = false;
            
        }

        human.transform.rotation = new Quaternion(0, 0, 0, 0);

        //Circle.isTouchObject = false;
        
    }


}

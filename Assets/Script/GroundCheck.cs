using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    public bool isGrounded;
    
    public GameObject human;
    public Collider2D Circle;

    private void Update()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = true;
    }


    private void OnTriggerStay2D(Collider2D collider)
    {

        isGrounded = collider != null && (((1 << collider.gameObject.layer) & platformLayerMask) != 0);

        if (collider.gameObject.name != "Full ")
        {
            human.transform.rotation = collider.transform.rotation;
        }

    }

    


    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Edge")
        //{
        //    Circle.isTrigger = false;
        //}

        isGrounded = false;
    }

    
}

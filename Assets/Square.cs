using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public GameObject childFullSquare;

    public void OnCollisionEnter2D(Collision2D collision)
    {

        // Bật đèn Object bị đạp vào
        childFullSquare.GetComponent<SpriteRenderer>().enabled = true;

        if (collision.gameObject.tag == "Circle")
        {
            // setparent cho circle
            collision.transform.SetParent(gameObject.transform);

            // set Kinematic cho circle
            collision.collider.GetComponent<Rigidbody2D>().isKinematic = true;

            // set Trigger cho circle
            collision.collider.GetComponent<Collider2D>().isTrigger = true;

        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Circle")
        {
            // unset Parent circle
            other.transform.SetParent(null);
        }

    }


    

}

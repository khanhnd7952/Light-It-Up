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
            //StartCoroutine(ExampleCoroutine(collision));

            // set Trigger cho circle
            collision.collider.GetComponent<Collider2D>().isTrigger = true;

        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Circle")
        {
            other.transform.SetParent(null);
            //other.isTrigger = false;
        }



        //other.isTrigger = false;
    }


    IEnumerator ExampleCoroutine(Collision2D collision)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.01f);

        
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public GameObject childFullSquare;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        // Bật đèn Object bị đạp vào
        childFullSquare.GetComponent<SpriteRenderer>().enabled = true;
        if (collision.gameObject.tag == "Circle")
        {
            // bật đèn Circle
            collision.collider.GetComponent<SpriteRenderer>().color = childFullSquare.GetComponent<SpriteRenderer>().color;

            // setparent cho circle
            collision.transform.SetParent(gameObject.transform);
            // set Kinematic cho circle
            collision.collider.GetComponent<Rigidbody2D>().isKinematic = true;
            // set Trigger cho circle
           // collision.collider.GetComponent<Collider2D>().isTrigger = true;

        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Object")
        {
            other.transform.SetParent(null);
        }

        other.isTrigger = false;
    }
}
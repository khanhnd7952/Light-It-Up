using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{

    public static Rigidbody2D rb;
    public static GameObject gameOb;
    public static bool doubleJump;
    public GameObject jump;

    public static int rotateDirection;
    private float rotateSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        doubleJump = false;
        rotateSpeed = 1000f;
    }


    void Update()
    {
        // rotate khi doublejump
        if ( !GroundCheck.isGrounded && !doubleJump  )
        {
            jump.transform.Rotate(new Vector3(0, 0, 1) * rotateDirection * rotateSpeed * Time.deltaTime);
            jump.GetComponent<SpriteRenderer>().color = Color.white;

        }
    }

    public static void DoJump(int jumpDirection)
    {
        // unset Kinematic cho Circle
        rb.isKinematic = false;

        if (GroundCheck.isGrounded)
        {
            rb.velocity = new Vector2(jumpDirection * 1.5f, 4f);
        }
        else if (doubleJump)
        {
            rb.velocity = new Vector2(jumpDirection * 1.5f, 4f);
            doubleJump = false;
        }

    }

    public void test()
    {
        Debug.Log("test");
    }    

}


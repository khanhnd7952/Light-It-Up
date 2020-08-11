using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOld : MonoBehaviour
{
    public static Rigidbody2D rb;
    public Transform groundCheckpoint;
    public float groundCheckRadius;
    [SerializeField]
    public LayerMask groundLayer;
    private static bool isTouchingGround;
    public PhysicsMaterial2D bounceMat, normalMat;
    private float speed;
    public int moveDirection;
    private static bool facingRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.sharedMaterial = normalMat;
        speed = 0f;
        moveDirection = 0;

    }
    void Update()
    {
        
        //isTouchingGround = Physics2D.OverlapCircle(groundCheckpoint.position, groundCheckRadius, groundLayer);
        isTouchingGround = IsGrounded();
        if (UIButton.moveDirection != 0 && IsGrounded())
        {
            moveDirection = UIButton.moveDirection;
            //rb.sharedMaterial = normalMat;
            //Debug.Log("nomal");
            IncreaseSpeed();
        }
        Debug.Log(" is Ground" + IsGrounded());
        Debug.Log("moveDirection" + UIButton.moveDirection);

        if (UIButton.moveDirection == 0 && IsGrounded())
        {
            //rb.sharedMaterial = normalMat;
            SpeedEqualZero();
        }

        if (!isTouchingGround)
        {
            //rb.sharedMaterial = bounceMat;
            DecreaseSpeed();
        }
        gameObject.transform.Translate(Vector3.left * moveDirection * speed * -5f * Time.deltaTime);
        Flip();
        


    }


    public bool IsGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }

    

    void IncreaseSpeed()
    {
        speed += Time.deltaTime;
        if (speed > 1) { speed = 1; }
    }

    void DecreaseSpeed()
    {
        speed -= Time.deltaTime;
        if (speed < 0) { speed = 0; }
    }

    void SpeedEqualZero()
    {
        speed = 0;
    }

    public static void DoJump(int jumpDirection, float jumpForce)
    {
        if (isTouchingGround)
        {
            rb.velocity = new Vector2(jumpDirection * 4 , 1.4f*jumpForce);
        }
       
    }

    public void Flip()
    {
        if (UIButton.moveDirection < 0 && !facingRight || UIButton.moveDirection > 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

        }
    }
}

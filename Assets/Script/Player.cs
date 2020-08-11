using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Rigidbody2D rb;
    private static bool isTouchingGround;
    private float speedMove;
    public int moveDirection;
    private static bool facingRight;
    public int fallCount;
    public float oldPosition;

    [SerializeField] 
    Text FallCount;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speedMove = 0f;
        moveDirection = 0;
        FallCount.text = "Fall: ";
        oldPosition = gameObject.transform.position.y;
    }
    void Update()
    {
        // check các trường hợp
        isTouchingGround = IsGrounded();

        if ( IsGrounded() )
        {

            FallCount.text = "Fall: " + fallCount.ToString();
            if (UIButton.moveDirection != 0)
            {
                moveDirection = UIButton.moveDirection;
                IncreaseSpeed();
            }
            else if (UIButton.moveDirection == 0)
            {
                SpeedEqualZero();
            }
            
            if ( oldPosition - gameObject.transform.position.y  > 1)
            {
                fallCount++;
            }
            oldPosition = gameObject.transform.position.y;

        }
        else
        {
            
            DecreaseSpeed();
        }

        // move
        gameObject.transform.Translate(Vector3.left * moveDirection * speedMove * -5f * Time.deltaTime);

        
        Flip();
    }
    
    public bool IsGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }

    void IncreaseSpeed()
    {
        speedMove += Time.deltaTime;
        if (speedMove > 1) { speedMove = 1; }
    }

    void DecreaseSpeed()
    {
        speedMove -= Time.deltaTime;
        if (speedMove < 0) { speedMove = 0; }
    }

    void SpeedEqualZero()
    {
        speedMove = 0;
    }

    public static void DoJump(int jumpDirection, float jumpForce)
    {
        if (isTouchingGround)
        {
            rb.velocity = new Vector2(jumpDirection * 4, jumpForce);
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

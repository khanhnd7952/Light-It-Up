using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject jump;
    [SerializeField] private GameObject climbLeft;
    [SerializeField] private GameObject climbRight;
    private static Rigidbody2D rb;
    private static Collider2D coll;

    


    [SerializeField] private float rotateSpeed;
    private static bool doubleJump;
    protected static int jumpDirection;
    private static float jumpSpeedX;
    private static float jumpSpeedY;

    public static Rigidbody2D Rb { get => rb; set => rb = value; }
    public static Collider2D Coll { get => coll; set => coll = value; }
    public GameObject Player { get => player; set => player = value; }
    public GameObject Jump { get => jump; set => jump = value; }
    public GameObject ClimbLeft { get => climbLeft; set => climbLeft = value; }
    public GameObject ClimbRight { get => climbRight; set => climbRight = value; }
    public static bool DoubleJump { get => doubleJump; set => doubleJump = value; }
    public static int RotateDirection { get => jumpDirection; set => jumpDirection = value; }
    public  float RotateSpeed { get => rotateSpeed; set => rotateSpeed = value; }
    public static float JumpSpeedX { get => jumpSpeedX; set => jumpSpeedX = value; }
    public static float JumpSpeedY { get => jumpSpeedY; set => jumpSpeedY = value; }
    

    void Start()
    {
        Coll = GetComponent<Collider2D>();
        Rb = GetComponent<Rigidbody2D>();
        DoubleJump = false;
        RotateSpeed = 1000f;
        JumpSpeedX = 1.5f;
        JumpSpeedY = 4.0f;
    }


    void Update()
    {
        // rotate khi doublejump
        if ( !GroundCheck.isGrounded && !DoubleJump  )
        {
            Jump.transform.Rotate(new Vector3(0, 0, 1) * RotateDirection * RotateSpeed * Time.deltaTime);
            Jump.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public static void DoJump(int jumpDirection)
    {
        // unset Kinematic cho Circle
        Rb.isKinematic = false;

        if (GroundCheck.isGrounded)
        {
            Rb.velocity = new Vector2(jumpDirection * JumpSpeedX, JumpSpeedY);
        }
        else if (DoubleJump)
        {
            Rb.velocity = new Vector2(jumpDirection * JumpSpeedX, JumpSpeedY);
            DoubleJump = false;
        }

    }

}


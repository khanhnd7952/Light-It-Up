using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    [SerializeField]
    Image jumpForceBar; // Thanh Lực Nhảy
    public float initJump;  // Giá trị nhảy nhỏ nhất
    public float jumpMultiply;
    public float holdTime;  // Thời gian Giữ nút nhảy [ 0 : 1 ]
    public static int moveDirection; // Hướng di chuyển left: -1, right : 1
    public static int jumpDirection; // Hướng nhảy left: -1, right : 1


    [SerializeField]
    Text jumpCount;

    public static int jumpcount = 0;
    void Start()
    {
        // Khởi tạo các giá trị ban đầu
        //jumpForceBar.fillAmount = 0;
        initJump = 2f;
        moveDirection =  0;
        jumpDirection = 1;
        jumpMultiply = 25;
        jumpCount.text = "Jump: ";
    }

    #region Cập nhật hướng khi bấm các nút di chuyển

    public void LeftPointerDowm()
    {
        moveDirection = jumpDirection = -1;
    }
    public void LeftPointerUp()
    {
        jumpDirection = -1;
        moveDirection = 0;
    }
    public void RightPointerDown()
    {
        moveDirection = jumpDirection = 1;
    }
    public void RightPointerUp()
    {
        jumpDirection = 1;
        moveDirection = 0;
    }
    #endregion
    public void JumpPointerDown()
    {
        jumpForceBar.fillAmount = 0f;
        StartCoroutine("StartCounting");
    }
    public void JumpPointerUp()
    {
        jumpcount++;
        jumpCount.text = "Jump: " + jumpcount.ToString();
        StopCoroutine("StartCounting");
        if (holdTime < 0.1f)
        {
            Player.DoJump(jumpDirection, initJump);

        }
        else
        {
            Player.DoJump(jumpDirection, holdTime * 10f);
            jumpForceBar.fillAmount = 0f;

        }
        jumpForceBar.fillAmount = 0;

        if (holdTime < 0.1)
        {
            Player.DoJump(jumpDirection, initJump);
        }
        else
        {
            Player.DoJump(jumpDirection, jumpMultiply*holdTime);
        }
        jumpForceBar.fillAmount = 0;

    }

    IEnumerator StartCounting()
    {
        for (holdTime = 0f; holdTime <= 0.5f; holdTime += Time.deltaTime)
        {
            jumpForceBar.fillAmount =2* holdTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        holdTime = 0.5f;
        jumpForceBar.fillAmount = 2* holdTime;
    }



}

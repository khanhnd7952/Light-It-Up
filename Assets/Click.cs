using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{


    public void ClickLeft()
    {

        // hướng nhảy và xoay
        Circle.DoJump(-1);

        Circle.RotateDirection = 1;


    }

    public void ClickRight()
    {
        // hướng nhảy và xoay
        Circle.DoJump(1);

        Circle.RotateDirection = -1;

    }
}

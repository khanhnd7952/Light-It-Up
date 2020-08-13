using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{


    public void ClickLeft()
    {

        Circle.DoJump(-1);
        
        Circle.rotateDirection = 1;


    }

    public void ClickRight()
    {

        Circle.DoJump(1);

        Circle.rotateDirection = -1;

    }
}

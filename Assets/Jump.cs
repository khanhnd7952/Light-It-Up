using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{


    public void ClickLeft()
    {
        
        //if ( Circle.isTouchObject )
        //{
        //    Circle.DoJump(-1);
        //}
        Circle.DoJump(-1);
        
        

    }

    public void ClickRight()
    {
        
        //if (Circle.isTouchObject)
        //{
        //    Circle.DoJump(1);
        //}
        Circle.DoJump(1);

    }
}

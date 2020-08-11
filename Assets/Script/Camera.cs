using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Player;
    private float charPosition;
    void Update()
    {
        charPosition = Player.position.y;
        Debug.Log(charPosition);
        if ( charPosition < 6.6)
        {
            gameObject.transform.position = new Vector3(-6f, 0f, -1f);
        }
        else if (6.6 < charPosition  && charPosition < 16.6 )
        {
            gameObject.transform.position = new Vector3(-6f, 10f, -1f);
        }
        else if (16.6 < charPosition && charPosition < 26.6)
        {
            gameObject.transform.position = new Vector3(-6f, 20f, -1f);
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotExit : MonoBehaviour
{
    public GameObject circle;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Exit!! Please Go Back!!");
        circle.transform.position = new Vector3(0, 0, 0);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesst : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
    }
}

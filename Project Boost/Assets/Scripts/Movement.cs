using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("space bas�ld�");
        }

        if (Input)
        {
            Debug.Log("sa� sol y�n");
        }

        if (Input.GetAxis("Vertical"))
        {
            Debug.Log("yukar� a�a�� y�n");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardNavigation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rotationX = 0f;
        float rotationZ = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            rotationX += 0.1f;
        }
        if (Input.GetKey((KeyCode.S)))
        {
            rotationX -= 0.1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rotationZ += 0.1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rotationZ -= 0.1f;
        }
        
        transform.rotation *= Quaternion.Euler(rotationX, 0f, rotationZ);
    }
    
}

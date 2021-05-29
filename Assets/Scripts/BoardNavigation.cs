using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BoardNavigation : MonoBehaviour
{
    private float previousXPosition = 0f;
    private float previousYPostion = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        float rotationX = 0f;
        float rotationZ = 0f;
        
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x - previousXPosition < 0)
            {
                rotationZ += 0.5f;
            }

            if (Input.mousePosition.x - previousXPosition > 0)
            {
                rotationZ -= 0.5f;
            }

            if (Input.mousePosition.y - previousYPostion < 0)
            {
                rotationX -= 0.5f;
            }

            if (Input.mousePosition.y - previousYPostion > 0)
            {
                rotationX += 0.5f;
            }
        }
        
        transform.rotation *= Quaternion.Euler(rotationX, 0f, rotationZ);
        previousXPosition = Input.mousePosition.x;
        previousYPostion = Input.mousePosition.y;
    }
    
}

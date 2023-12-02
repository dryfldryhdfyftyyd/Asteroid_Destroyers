using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up_down : MonoBehaviour
{

    public float rotationAngle = 45f;

    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            RotateDown();
        }
        
        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            RotateUp();
        }
    }

    void RotateDown()
    {
        
        transform.Rotate(Vector3.right, rotationAngle * Time.deltaTime);
    }

    void RotateUp()
    {
        
        transform.Rotate(Vector3.left, rotationAngle * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RotateTest : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, 0.05f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpin : MonoBehaviour
{
    public float spinSpeed = 360f; // Speed in degrees per second

    void Update()
    {
        // Rotate the fan blade around its Y-axis
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}


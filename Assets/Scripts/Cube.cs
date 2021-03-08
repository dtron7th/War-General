using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Smooth towards the height of the target

    Transform target;
    public float smoothTime = 0.3f;
    public float yVelocity = 0.0f;
    public float Speed;

    void Update()
    {
        

        if (Input.GetKey(KeyCode.R)) {
            transform.Translate (Vector3.forward * Speed);
        }
    }
}
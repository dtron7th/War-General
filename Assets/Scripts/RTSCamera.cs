using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCamera : MonoBehaviour
{

    public float Move_Speed = 0.3f;
    public float Orbit_Speed;
    public float Zoom_Speed;

    public GameObject Camera;

    // Update is called once per frame
    void Update()
    {
        Moving ();
        Orbit ();
    }

    void Moving() {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate (Vector3.forward * Move_Speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate (Vector3.back * Move_Speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate (Vector3.left * Move_Speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate (Vector3.right * Move_Speed);
        }
    }

    void Orbit() {
        
    }
}



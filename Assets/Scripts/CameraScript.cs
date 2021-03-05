using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraScript : MonoBehaviour
{
    public CinemachineVirtualCamera VCam;

    [Header("Movement")]
    public float Move_Speed = 1.0f;
    public float Orbit_Speed;
    public float Zoom_Speed;
    public float Drag = 5f;

    [Header("Orbiting")]
    public float DownSpeed = 5f;
    float yOffset;
    public float maxYOffset = 1f;
    public float minYOffset = 10f;
    private float Rotation_X ;
    private float Rotation_Y ;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        
        Moving ();
        Orbit ();
        Zooming ();
    }

    void Moving() {
        rb.drag = Drag;

        //forward back
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * Time.deltaTime * Move_Speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * Time.deltaTime * Move_Speed);
        }

        //left and right
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * Time.deltaTime * Move_Speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * Time.deltaTime * Move_Speed);
        }
    }

    void Orbit () {
        
        if (Input.GetAxis("Mouse Y") > 0)
        {
            yOffset = Mathf.Lerp(yOffset, minYOffset, Time.deltaTime * DownSpeed);
        }
        else if (Input.GetAxis("Mouse Y") < 0)
        {
            yOffset = Mathf.Lerp(yOffset, maxYOffset, Time.deltaTime * DownSpeed);
        }

        VCam.GetCinemachineComponent<CinemachineOrbitalTransposer>().m_FollowOffset.y = yOffset;
    }

    void Zooming () {
        float Zoom_In = Zoom_Speed;

        if (Input.mouseScrollDelta.y > 0 ){
             
            
        }

         if (Input.mouseScrollDelta.y < 0 ){
             
            
        }
    }
}

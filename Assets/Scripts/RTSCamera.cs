using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCamera : MonoBehaviour
{
    [Header("Moving")]
    public float Min_ZoomDistance = -5f;
    public float Max_ZoomDistance = -10f;
    public float Min_Move_Speed = 0.3f;
    public float Max_Move_Speed = 10f;
    public float Move_Speed_Multiplier = 2f;
    private float Move_Speed = 0.3f;
    public float Orbit_Speed;

    [Header("Zooming")]
    public float Zoom_Speed = 5.0f;
    private float actualZoomSpeed;
    //speed matching distance
    public float Min_Zoom_Speed = 5.0f;
    public float Max_Zoom_Speed = 20f;
    
    public float Zoom_Multiplier;

    private float actualMoveSpeed;
    

    public GameObject Camera;
    public GameObject Camera_Y;

    private float Rotation_X;
    private float Rotation_Y;

    //[Header("Smoothing")]

    //public float SmoothTime = 0.3f;

    private void Awake()
    {
        actualZoomSpeed = Zoom_Speed;
        actualMoveSpeed = Move_Speed;
        Camera.transform.localPosition = new Vector3(0, 0, Max_ZoomDistance);
    }

    // Update is called once per frame
    void Update() {
        
        //Mathf.Lerp (0, 0, SmoothTime);

        Moving ();
        Orbit ();
        Zooming ();
    }

    void Moving() {

        if (Input.GetKey(KeyCode.W)) {
            transform.Translate (Vector3.forward * Move_Speed);
        }

        if (Input.GetKey(KeyCode.S)) {
            transform.Translate (Vector3.back * Move_Speed);
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.Translate (Vector3.left * Move_Speed);
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Translate (Vector3.right * Move_Speed);
        }
    }

    void Orbit() {

        if (Input.GetMouseButton(2)) {
            Rotation_X += Input.GetAxis("Mouse X") * Orbit_Speed;
        }
        if (Input.GetMouseButton(2)) {
            Rotation_Y -= Input.GetAxis("Mouse Y") * Orbit_Speed;
        }

        transform.eulerAngles = new Vector3( 0, Rotation_X, 0);
        Camera_Y.transform.eulerAngles = new Vector3( Rotation_Y, Rotation_X, 0);
        
        
    }

    void Zooming() {
        if (Camera.transform.localPosition.z > Min_ZoomDistance)
            Camera.transform.localPosition = new Vector3(0, 0, Min_ZoomDistance);
        else if (Camera.transform.localPosition.z < Max_ZoomDistance)
            Camera.transform.localPosition = new Vector3(0, 0, Max_ZoomDistance);
        else
            Camera.transform.Translate(0, 0, Input.mouseScrollDelta.y * Zoom_Speed);

        Move_Speed += Input.mouseScrollDelta.y * Move_Speed_Multiplier;
        Move_Speed = Mathf.Clamp(Move_Speed, Min_Move_Speed, Max_Move_Speed);

        Zoom_Speed -= Input.mouseScrollDelta.y * Zoom_Multiplier;
        Zoom_Speed = Mathf.Clamp(Zoom_Speed, Min_Zoom_Speed, Max_Zoom_Speed);
    }
}



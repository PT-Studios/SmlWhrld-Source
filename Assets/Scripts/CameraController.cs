using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float hozMove = 2.0f;
    public float verMove = 2.0f;

    public float yaw = 0.0f;
    private float pitch = 0.0f;

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        MouseAim();
	}

    void MouseAim()
    {
        yaw += hozMove * Input.GetAxis("Mouse X");
        pitch -= verMove * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}

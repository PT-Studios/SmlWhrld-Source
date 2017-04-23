using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public float mSpeed = 5.0f;
    public CameraController myCam;
    public ScaleController sC;

    private float yaw;
    private bool isColliding = false;


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        //Move Player with Camera
        yaw = myCam.yaw;
        transform.eulerAngles = new Vector3(0, yaw, 0.0f);

        //Move on Keypress
        KeyMovement();
        
    }

    void KeyMovement()
    {
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            mSpeed = 10f;
        } else
        {
            mSpeed = 5.0f;
        }
        float scaledSpeed = mSpeed * sC.scale.x;
        if (!isColliding)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                //Debug.Log("Pressing A");
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - transform.right * scaledSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                //Debug.Log("Pressing W");
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.forward * scaledSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                //Debug.Log("Pressing S");
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - transform.forward * scaledSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                //Debug.Log("Pressing D");
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.right * scaledSpeed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {

    }

    void FixedUpdate()
    {
        Rigidbody rid = gameObject.GetComponent<Rigidbody>();
        rid.AddForce(Physics.gravity * 100);
    }
}

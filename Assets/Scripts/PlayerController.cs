using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Camera myCam;
    public GameObject winObj;
    public ScaleController sC;

    public float boxScaleSpeed = 0.25f;
    public float pullSpeed = 8.0f;
    public float pointDistance = 2.0f;
    public float minScale = 0.25f;
    public float maxScale = 50f;

    bool pickUp = false;
    Transform heldObject;
    AudioSource audios;

    // Use this for initialization
    void Start () {
        audios = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (pickUp)
        {
            float s;
            var d = Input.GetAxis("Scale Held Object");
            var targetPoint = Camera.main.transform.TransformPoint(Vector3.forward * pointDistance);
            s = heldObject.localScale.x;
            Rigidbody rb = heldObject.GetComponent<Rigidbody>();

            //Move to TargetPos
            rb.MovePosition(Vector3.Lerp(heldObject.position, targetPoint, Time.deltaTime * pullSpeed));

            //Scale Pickup
            if (d > 0f)
            {
                s = (s + boxScaleSpeed);
                s = Mathf.Clamp(s, minScale, maxScale);
                heldObject.transform.localScale = new Vector3(s, s, s);
                audios.pitch = s;
                audios.Play();
            }
                
            if(d < 0f)
            {
                s = (s - boxScaleSpeed);
                s = Mathf.Clamp(s, minScale, maxScale);
                heldObject.transform.localScale = new Vector3(s, s, s);
                audios.pitch = s;
                audios.Play();
            }

        }

        if (Input.GetKey(KeyCode.E))
        {
            RaycastHit hit;
            GameObject hitObj;
            
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, (Screen.height / 2), 0));
            if (Physics.Raycast(ray, out hit, (2+sC.scale.x)))
            {
                hitObj = hit.collider.gameObject;
                
                if (hitObj == winObj)
                {
                    heldObject = hit.transform;
                    //winObj.transform.parent = transform;
                    winObj.GetComponent<Rigidbody>().useGravity = false;
                    pickUp = true;
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.E) && pickUp)
        {
            //winObj.transform.parent = null;
            winObj.GetComponent<Rigidbody>().useGravity = true;
            pickUp = false;

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void ForceDrop()
    {
        winObj.transform.parent = null;
        winObj.GetComponent<Rigidbody>().useGravity = true;
        pickUp = false;
    }
}

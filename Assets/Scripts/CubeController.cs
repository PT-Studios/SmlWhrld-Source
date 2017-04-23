using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag != "WinZone" && coll.gameObject.tag != "Floor")
        {
            if (transform.parent != null)
            {
                transform.parent.GetComponent<Collider>().attachedRigidbody.SendMessage("OnCollisionEnter", coll);
            }
        }
        
    }
}

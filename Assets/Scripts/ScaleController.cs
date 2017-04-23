using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleController : MonoBehaviour {

    public float scaleSpeed = 0.1f;
    public float sMin = 1f;
    public float sMax = 100f;
    public Vector3 scale;

    // Use this for initialization
    void Start () {
        //scale = GetComponent<MeshRenderer>().bounds.size;
        scale = transform.localScale;
        //rot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        scale = transform.localScale;
        
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.LeftControl))
        {
            ScaleObject(scale, 0);
        }
        if (Input.GetMouseButton(1) || Input.GetKey(KeyCode.LeftAlt))
        {
            ScaleObject(scale, 1);
        }
    }

    void ScaleObject(Vector3 scale, int dir)
    {
        float s = 0;
        s = Mathf.Clamp(s, sMin, sMax);
        if (dir == 0)
        {
            s = scale.x - (1+scaleSpeed*scale.x)*Time.deltaTime;
            if (s > sMin)
            {
                if (s <= sMin)
                    s = sMin;
                transform.localScale = new Vector3(s, s, s);
            }
        } else
        {
            s = scale.x + (1 + scaleSpeed*scale.x) * Time.deltaTime;
            if (s < sMax)
            {
                if (s >= sMax)
                    s = sMin;
                transform.localScale = new Vector3(s, s, s);
            }
        }
    }
    //End Class
}

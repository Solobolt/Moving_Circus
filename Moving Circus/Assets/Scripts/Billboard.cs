using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

    private Transform myTransform;

	// Use this for initialization
	void Start () {
        myTransform = this.transform;
	}

    // Update is called once per frame
    void Update()
    {
        if(Camera.main.orthographic == true)
        {
            myTransform.rotation = Camera.main.transform.rotation;
        }
        else
        {
            transform.LookAt(Camera.main.transform.position, Vector3.up);
        }
    }
}

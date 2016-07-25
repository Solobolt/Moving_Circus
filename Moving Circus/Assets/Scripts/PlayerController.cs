using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//holds player transform
	private Transform myTransform;

	//Holds speed the the player moves per frame (Will be scaled to time.delt time)
	public float moveSpeed = 10.0f;

	// Use this for initialization
	void Start () {
		//Initialises transform
		myTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        MovePlayer();
	}

	//handels player Movement
	void MovePlayer()
	{
        Vector3 tempPos = myTransform.position;

		if(Input.GetAxis("Horizontal") != 0)
		{
            tempPos.x += Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            tempPos.z += Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        }

        myTransform.position = tempPos;
    }
}

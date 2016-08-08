using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private GameObject player;
    private Transform myTransfrom;

    #region CamOffsets
    private Vector3 camOffset = new Vector3(0,12.0f,-13.0f);
    private Vector3 maxLimits = new Vector3(10.0f,12.0f,-13.0f);
    private Vector3 minLimits = new Vector3(-20.0f,12.0f,-20.0f);
    #endregion;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        myTransfrom = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        MoveCamera();
	}

    //makes the camrea follow the player
    void MoveCamera()
    {
        Vector3 tempPos = (player.transform.position + camOffset);


        if (tempPos.x >= maxLimits.x)
        {
            tempPos.x = maxLimits.x;
        }

        if (tempPos.x <= minLimits.x)
        {
            tempPos.x = minLimits.x;
        }

        tempPos.z = maxLimits.z;


        myTransfrom.position = tempPos;
    }
}

using UnityEngine;
using System.Collections;

public class NPCPlacement : MonoBehaviour {

    private Vector3 offScreen = new Vector3(1000.0f,0.0f,1000.0f);

    public GameObject[] NPCs = new GameObject[5];


    // Use this for initialization
    void Start () {
        foreach(GameObject i in NPCs)
        {
            i.transform.position = offScreen;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

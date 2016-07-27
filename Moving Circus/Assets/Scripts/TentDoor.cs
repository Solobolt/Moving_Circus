using UnityEngine;
using System.Collections;

public class TentDoor : MonoBehaviour {

    private GameObject caravan;

	// Use this for initialization
	void Start () {
        caravan = GameObject.FindGameObjectWithTag("Caravan");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            if(coll == coll.gameObject.GetComponent<CapsuleCollider>())
            {
                coll.gameObject.transform.position = caravan.transform.position;
            }
        }
    }
}

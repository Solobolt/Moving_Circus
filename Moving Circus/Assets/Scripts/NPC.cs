using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

    public bool canTalk = false;

	// Use this for initialization
	void Start () {
  
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Hides and shows wether or not the NPC can be interacted with
    void IconVisbility()
    {
        if(canTalk)
        {
            //Show Icon
        }
        else
        {
            //Hide Icon
        }
    }

    //Handles what happens when the player interacts with the NPC
    public void Interact()
    {

    }
}

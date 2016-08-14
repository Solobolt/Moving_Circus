using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HighlightNPC : MonoBehaviour {

    public GameObject[] NPCList;

    public GameObject arrow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Highlight(string NPCname)
    {
        foreach(GameObject NPC in NPCList)
        {
            if(NPC.gameObject.name != NPCname)
            {
                if(NPC.gameObject.GetComponentInChildren<Canvas>() != null)
                {
                    Destroy(NPC.gameObject.GetComponentInChildren<Canvas>());
                }
            }
            else
            {
                Instantiate(arrow,NPC.transform);
            }
        }
    }
}

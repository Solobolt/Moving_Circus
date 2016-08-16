using UnityEngine;
using System.Collections;
using Fungus;

public class HighlightNPC : MonoBehaviour {

    public GameObject arrow;

    public Flowchart flowchart;

    private string characterName;

	// Use this for initialization
	void Start () {
        characterName = this.gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {
        checkFlowchart();
	}

    void checkFlowchart()
    {
        if (flowchart.GetBooleanVariable(characterName + "CanTalk") == true)
        {
            arrow.gameObject.SetActive(true);
        }
        else
        {
            arrow.gameObject.SetActive(false);
        }
    }
}

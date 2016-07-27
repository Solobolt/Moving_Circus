using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Fungus;

public class GameManager : SingletonBehaviour<GameManager>
{
    public Flowchart flowchart;
    public int timePos = 1;

    public GameObject[] posPrefabs;

	// Use this for initialization
	void Start () {
        setPositions();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void nextDay()
    {
        timePos++;
        flowchart.SetIntegerVariable("timePos",timePos);

        setPositions();
    }

    void setPositions()
    {
        for (int i = 0; i < posPrefabs.Length; ++i)
        {
            if (i != timePos - 1)
            {
                posPrefabs[i].SetActive(false);
            }
            else
            {
                posPrefabs[i].SetActive(true);
            }
        }
    }
}

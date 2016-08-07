﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Fungus;

public class GameManager : SingletonBehaviour<GameManager>
{
    public Flowchart flowchart;
    public int timePos = 1;

    public GameObject[] posPrefabs;

    private GameObject player;
    private GameObject caravan;

	// Use this for initialization
	void Start () {
        setPositions();
        player = GameObject.FindGameObjectWithTag("Player");
        caravan = GameObject.FindGameObjectWithTag("Caravan");
        SetCanTalks();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void nextDay()
    {
        timePos++;
        flowchart.SetIntegerVariable("timePos",timePos);

        setPositions();
        SetCanTalks();
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

    public void StartNextDay()
    {
        player.transform.position = caravan.transform.position;
        nextDay();
    }

    //Allows the player to talk to people when we intent them to
    void SetCanTalks()
    {
        //Sets who can talk depending on the day, this can be over-wriden by the CharacterCanTalk() function
        switch (timePos)
        {
            case 1:
                CharacterCanTalk("Adolf", false);
                CharacterCanTalk("Enrico", true);
                CharacterCanTalk("Nala", false);
                CharacterCanTalk("Pierre", false);
                CharacterCanTalk("Jo", false);
                break;

            case 2:
                CharacterCanTalk("Adolf", false);
                CharacterCanTalk("Enrico", false);
                CharacterCanTalk("Nala", false);
                CharacterCanTalk("Pierre", true);
                CharacterCanTalk("Jo", false);
                break;

            default:
                CharacterCanTalk("Adolf", false);
                CharacterCanTalk("Enrico", false);
                CharacterCanTalk("Nala", false);
                CharacterCanTalk("Pierre", false);
                CharacterCanTalk("Jo", false);
                break;
        }
    }

    //Sets an indevidual characters can talk state
    public void CharacterCanTalk(string characterName, bool setTrueFalse)
    {
        flowchart.SetBooleanVariable(characterName+"CanTalk", setTrueFalse);
    }

    //An unfortunate side effect of fungus
    //Adolf
    public void AdolfTrueCanTalk()
    {
        CharacterCanTalk("Adolf", true);
    }

    public void AdolfFalseCanTalk()
    {
        CharacterCanTalk("Adolf", false);
    }

    //Enrico
    public void EnricoTrueCanTalk()
    {
        CharacterCanTalk("Enrico", true);
    }

    public void EnricoFalseCanTalk()
    {
        CharacterCanTalk("Enrico", false);
    }
}

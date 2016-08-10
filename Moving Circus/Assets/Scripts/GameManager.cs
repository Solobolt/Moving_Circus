using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Fungus;

public class GameManager : SingletonBehaviour<GameManager>
{
    public Flowchart flowchart;
    public int timePos = 1;

    public GameObject[] posPrefabs;

    private GameObject player;
    private GameObject caravan;

    public UIManager uiManager;

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

    //Sets the player Controller script to disabled
    public void DisablePlayerControls()
    {
        player.GetComponent<PlayerController>().enabled = false;
    }

    //Sets the player Controller script to enabled
    public void EnablePlayerControls()
    {
        player.GetComponent<PlayerController>().enabled = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void nextDay()
    {
        timePos++;
        flowchart.SetIntegerVariable("timePos",timePos);

        //ends the game if using debugging cube
        if(timePos > 7)
        {
            LoadMainMenu();
        }

        setPositions();
        SetCanTalks();
    }

    //Moves Characters
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

    //Advances the day
    public void StartNextDay()
    {
        player.transform.position = caravan.transform.position;
        nextDay();
        uiManager.FadeScreenIn();
        EnablePlayerControls();
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

            case 3:
                CharacterCanTalk("Adolf", true);
                CharacterCanTalk("Enrico", false);
                CharacterCanTalk("Nala", false);
                CharacterCanTalk("Pierre", false);
                CharacterCanTalk("Jo", false);
                break;

            case 4:
                CharacterCanTalk("Adolf", false);
                CharacterCanTalk("Enrico", false);
                CharacterCanTalk("Nala", false);
                CharacterCanTalk("Pierre", false);
                CharacterCanTalk("Jo", true);
                break;

            case 5:
                CharacterCanTalk("Adolf", false);
                CharacterCanTalk("Enrico", true);
                CharacterCanTalk("Nala", false);
                CharacterCanTalk("Pierre", false);
                CharacterCanTalk("Jo", false);
                break;

            case 6:
                CharacterCanTalk("Adolf", false);
                CharacterCanTalk("Enrico", false);
                CharacterCanTalk("Nala", false);
                CharacterCanTalk("Pierre", false);
                CharacterCanTalk("Jo", true);
                break;

            case 7:
                CharacterCanTalk("Adolf", true);
                CharacterCanTalk("Enrico", false);
                CharacterCanTalk("Nala", false);
                CharacterCanTalk("Pierre", false);
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

    #region CanTalks
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

    //Pierre
    public void PierreTrueCanTalk()
    {
        CharacterCanTalk("Pierre", true);
    }

    public void PierreFalseCanTalk()
    {
        CharacterCanTalk("Pierre", false);
    }

    //Jo
    public void JoTrueCanTalk()
    {
        CharacterCanTalk("Jo", true);
    }

    public void JoFalseCanTalk()
    {
        CharacterCanTalk("Jo", false);
    }
    #endregion
}

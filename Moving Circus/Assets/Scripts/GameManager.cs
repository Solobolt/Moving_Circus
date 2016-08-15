using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Fungus;

public class GameManager : SingletonBehaviour<GameManager>
{
    public Flowchart flowchart;
    public int timePos = 1;
    public Text dateText;
    public GameObject date;
    public GameObject dateToDestroy;

    public GameObject[] posPrefabs;

    private GameObject player;
    private GameObject caravan;

    public UIManager uiManager;

    // Use this for initialization
    void Start()
    {
        setPositions();
        player = GameObject.FindGameObjectWithTag("Player");
        caravan = GameObject.FindGameObjectWithTag("Caravan");
        SetCanTalks();
        CheckDate();
        Destroy(dateToDestroy, 8f);
    }

    // Update is called once per frame
    void Update()
    {


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

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void nextDay()
    {
        date.SetActive(false);
        timePos++;
        flowchart.SetIntegerVariable("timePos", timePos);

        //ends the game if using debugging cube
        if (timePos > 8)
        {
            //LoadMainMenu();
            LoadCredits();
        }

        setPositions();
        SetCanTalks();
        player.gameObject.GetComponent<PlayerAnimationManager>().UnlockPlayerToIdle();
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

    void CheckDate()
    {
        switch (timePos)
        {
            case 7:
                dateText.text = "September 02, 1945. ( seventeen Months later )";
                break;

            case 6:
                dateText.text = "April 23, 1944. ( fifteen Months later )";
                break;

            case 5:
                dateText.text = "January 01, 1943. ( sixteen Months later )";
                break;

            case 4:
                dateText.text = "September 12, 1941. ( sixteen Months later )";
                break;

            case 3:
                dateText.text = "May 07, 1940. ( eight Months later )";
                break;

            case 2:
                dateText.text = "September 15, 1939. ( six Months later )";
                break;

            case 1:
                dateText.text = "March 04, 1939";
                break;

        }
    }

    //Advances the day
    public void StartNextDay()
    {
        player.transform.position = caravan.transform.position;
        nextDay();
        uiManager.FadeScreenIn();
        CheckDate();
        date.SetActive(true);
        print(timePos);
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
                CharacterCanTalk("Troop", false);
                break;

            case 2:
                CharacterCanTalk("Adolf", false);
                CharacterCanTalk("Enrico", false);
                CharacterCanTalk("Nala", false);
                CharacterCanTalk("Pierre", true);
                CharacterCanTalk("Jo", false);
                CharacterCanTalk("Troop", false);
                break;

            case 3:
                CharacterCanTalk("Adolf", true);
                CharacterCanTalk("Enrico", false);
                CharacterCanTalk("Nala", false);
                CharacterCanTalk("Pierre", false);
                CharacterCanTalk("Jo", false);
                CharacterCanTalk("Troop", false);
                break;

            case 4:
                CharacterCanTalk("Adolf", false);
                CharacterCanTalk("Enrico", false);
                CharacterCanTalk("Nala", false);
                CharacterCanTalk("Pierre", false);
                CharacterCanTalk("Jo", true);
                CharacterCanTalk("Troop", false);
                break;

            case 5:
                CharacterCanTalk("Adolf", false);
                CharacterCanTalk("Enrico", false);
                CharacterCanTalk("Nala", false);
                CharacterCanTalk("Pierre", false);
                CharacterCanTalk("Jo", false);
                CharacterCanTalk("Troop", true);
                break;

            case 6:
                CharacterCanTalk("Adolf", false);
                CharacterCanTalk("Enrico", true);
                CharacterCanTalk("Nala", false);
                CharacterCanTalk("Pierre", false);
                CharacterCanTalk("Jo", false);
                CharacterCanTalk("Troop", false);
                break;

            case 7:
                CharacterCanTalk("Adolf", false);
                CharacterCanTalk("Enrico", false);
                CharacterCanTalk("Nala", false);
                CharacterCanTalk("Pierre", false);
                CharacterCanTalk("Jo", true);
                CharacterCanTalk("Troop", false);
                break;

            case 8:
                CharacterCanTalk("Adolf", true);
                CharacterCanTalk("Enrico", false);
                CharacterCanTalk("Nala", false);
                CharacterCanTalk("Pierre", false);
                CharacterCanTalk("Jo", false);
                CharacterCanTalk("Troop", false);
                break;


            default:
                CharacterCanTalk("Adolf", false);
                CharacterCanTalk("Enrico", false);
                CharacterCanTalk("Nala", false);
                CharacterCanTalk("Pierre", false);
                CharacterCanTalk("Jo", false);
                CharacterCanTalk("Troop", false);
                break;
        }
    }

    //Sets an indevidual characters can talk state
    public void CharacterCanTalk(string characterName, bool setTrueFalse)
    {
        flowchart.SetBooleanVariable(characterName + "CanTalk", setTrueFalse);
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

    //Troop
    public void TroopTrueCanTalk()
    {
        CharacterCanTalk("Troop", true);
    }

    public void TroopFalseCanTalk()
    {
        CharacterCanTalk("Troop", false);
    }
    #endregion
}

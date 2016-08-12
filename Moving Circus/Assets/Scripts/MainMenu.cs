using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Button[] buttons;
    private int currentButton = 0;

    bool hasDone = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ControllerInputs();
	}

    //registers controller input
    void ControllerInputs()
    {
        if(Input.GetAxis("Vertical") > 0.0f)
        {
            currentButton = 0;
            buttons[currentButton].Select();
        }
        if (Input.GetAxis("Vertical") < 0.0f)
        {
            currentButton = 1;
            buttons[currentButton].Select();
        }
    }

    public void PlayScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                //Stop playing the scene
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
                Application.Quit();
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public GameObject endCredits;
    public Camera camera;

    // Use this for initialization
    void Start () {

        camera = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 viewPos = camera.WorldToViewportPoint(endCredits.transform.position);
        if (viewPos.y >= 1f)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

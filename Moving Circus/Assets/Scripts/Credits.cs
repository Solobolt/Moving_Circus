using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public GameObject endCredits;
    public GameObject credits;
    public GameObject quotes;
    public Camera camera;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(ScrollCredits(9.0f));
        camera = GetComponent<Camera>();
    
    }
	
	// Update is called once per frame
	void Update ()
    {

        Vector3 viewPos = camera.WorldToViewportPoint(endCredits.transform.position);
        if (viewPos.y >= 1f)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public IEnumerator ScrollCredits(float waitTime)
    {
        quotes.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        quotes.SetActive(false);
        credits.SetActive(true);
    }
}

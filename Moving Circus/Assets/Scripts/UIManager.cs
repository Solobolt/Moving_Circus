using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    public Image screenFadeImage;

    private float t = 0.0f;
    private float fadeTime = 0.5f;
    private float minA = 0.0f;
    private float maxA = 1.0f;

    private float minT = 0.0f;
    private float maxT = 1.0f;

    private enum FadeState
    {
        fadeIn,
        fadeOut,
        idle
    }
    private FadeState currentFadeState = FadeState.idle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
      switch(currentFadeState)
        {
            case FadeState.idle:
                break;

            case FadeState.fadeIn:
                if (t != 0.0f)
                {
                    screenFadeImage.color = new Color(0, 0, 0, Mathf.Pow(Mathf.Lerp(minA, maxA, t),2));

                    t -= fadeTime * Time.deltaTime;

                    if (t < minT)
                    {
                        t = minT;
                        currentFadeState = FadeState.idle;
                    }
                }
                break;

            case FadeState.fadeOut:
                if (t != 1.0f)
                {
                    screenFadeImage.color = new Color(0, 0, 0, Mathf.Pow(Mathf.Lerp(minA, maxA, t), 2));

                    t += fadeTime * Time.deltaTime;

                    if (t > maxT)
                    {
                        t = maxT;
                        currentFadeState = FadeState.idle;
                    }
                }
                break;
        }
    }

    public void FadeScreenOut()
    {
        currentFadeState = FadeState.fadeOut;
    }

    public void FadeScreenIn()
    {
        currentFadeState = FadeState.fadeIn;
    }

    /*public IEnumerator ShowDate(int day)
    {

    }*/
}

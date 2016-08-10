using UnityEngine;
using System.Collections;

public class TalkLightGlow : MonoBehaviour {

    Light thisLight;

    float loopTime = 3.0f;

    float iRange = 1.0f;
    float minI = 1.0f;

    float tempI = 0.0f;
    bool growing = false;

	// Use this for initialization
	void Start () {
        thisLight = this.gameObject.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if(growing == true)
        {
            tempI += Time.deltaTime * (2.0f / loopTime);
            if(tempI > iRange)
            {
                growing = false;
            }
        }
        else
        {
            tempI -= Time.deltaTime * (2.0f / loopTime);
            if (tempI < 0.0f)
            {
                growing = true;
            }
        }
        thisLight.intensity = tempI + minI;
    }
}

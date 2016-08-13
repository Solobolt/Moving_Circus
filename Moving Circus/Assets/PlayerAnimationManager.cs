using UnityEngine;
using System.Collections;

public class PlayerAnimationManager : MonoBehaviour {
    private Animator anim;

    private bool animationLock = false;

    // Use this for initialization
    void Start () {
        anim = this.gameObject.GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            anim.Play("idle");
        }

        if (animationLock == false)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                anim.Play("standard_walk");
            }

            if (Input.GetAxis("Vertical") != 0)
            {
                anim.Play("standard_walk");
            }
        }
        else
        {
            anim.Play("Idle");
        }
    }

    public void LockPlayerToIdle()
    {
        animationLock = true;
    }

    public void UnlockPlayerToIdle()
    {
        animationLock = false;
    }
}

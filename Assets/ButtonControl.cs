using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class ButtonControl : MonoBehaviour
{

    public AudioClip hoverSound;
    public AudioClip clickSound;

    public void PlayHoverSound()
    {
        Debug.Log("enter");
        GetComponent<AudioSource>().PlayOneShot(hoverSound);
    }

    public void PlayClickSound()
    {
        GetComponent<AudioSource>().PlayOneShot(clickSound);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TaxiScene : MonoBehaviour
{
    public DialogueSO taxiDialogue;
    private bool switchy = false;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("Fader").GetComponent<Fade>().In(2f);
        //SoundManager.Instance.deepBgm.start();
        SoundManager.Instance.taxiEvent.start();
    }

    // Update is called once per frame
    void Update()
    {
        if (!switchy)
        {
            DialogueManager.Instance.Dialogue = taxiDialogue;
            Debug.Log("INTERACTION");
            //DialogueManager.Instance.Next();
            switchy = true;
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            
            Debug.Log("INTERACTION");
            DialogueManager.Instance.Next();
        }
        if (DialogueManager.Instance.completedDialogues.Contains(taxiDialogue))
        {
            StartCoroutine(SceneTransition());
        }
    }

    IEnumerator SceneTransition()
    {
        yield return new WaitForSeconds(0.5f);
        //GameObject.Find("UI").GetComponent<Image>().enabled = true;
        SoundManager.Instance.taxiEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        SceneManager.LoadScene("Black");
        //SoundManager.Instance.PlayBusSound();
        
        

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScene : MonoBehaviour
{

    public DialogueSO introDialogue;
    private bool switchy = false;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("Fader").GetComponent<Fade>().In(2f);
        SoundManager.Instance.deepBgm.start();
    }

    // Update is called once per frame
    void Update()
    {
        if (!switchy) {
            DialogueManager.Instance.Dialogue = introDialogue;
            switchy = true;
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("INTERACTION");
            DialogueManager.Instance.Next();
        }
        if (DialogueManager.Instance.completedDialogues.Count == 1) 
        {
            
            StartCoroutine(SceneTransition());
        }
    }

    IEnumerator SceneTransition()
    {
        yield return new WaitForSeconds(0.5f);
        //GameObject.Find("UI").GetComponent<Image>().enabled = true;
        //SceneManager.LoadScene("WakeUp");
        SceneManager.LoadScene("Black");
        SoundManager.Instance.deepBgm.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //SoundManager.Instance.houseBgm.start();
    }
}

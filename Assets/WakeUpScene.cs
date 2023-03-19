using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WakeUpScene : MonoBehaviour
{
    public DialogueSO wakeDialogue;
    private bool switchy = false;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("Fader").GetComponent<Fade>().In(2f);
        //SoundManager.Instance.deepBgm.start();
    }

    // Update is called once per frame
    void Update()
    {
        if (!switchy)
        {
            DialogueManager.Instance.Dialogue = wakeDialogue;
            Debug.Log("INTERACTION");
            //DialogueManager.Instance.Next();
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
        //GameManager.UIOn();
        //GameObject.Find("UI").GetComponent<Image>().enabled = true;
        //GameObject.Find("GUI").SetActive(true);
        SceneManager.LoadScene("House");
        GameObject.Find("Player").transform.position = new Vector2(4.047618f, -15.33084f);
        SoundManager.Instance.deepBgm.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        SoundManager.Instance.houseBgm.start();
        
    }
}

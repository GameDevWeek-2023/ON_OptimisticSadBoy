using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HometownLogic : MonoBehaviour
{
    private bool inReturnDialogue = false;
    private bool selfSwitch = false;
    private bool selfSwitch2 = false;
    private bool selfSwitch3 = false;
    private bool selfSwitch4 = false;
    private bool selfSwitch5 = false;
    public GameObject taxiTrigger;
    public DialogueSO returnDialogue;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameManager.switchIndex);
        if (GameManager.backFromSchool && !GameManager.schoolReturn)
        {
            SoundManager.Instance.outsideBgm.start();
            GameManager.cameFromWakeUp = false;
            GameObject.Find("Player").transform.position = new Vector2(16.27f, -14.96f);
            GameManager.schoolReturn = true;
            
            inReturnDialogue = true;            
        }
        if (GameManager.backFromSchool && !selfSwitch)
        {
            GameObject.Find("BUS").SetActive(false);
            selfSwitch = true;
        }
        if (GameManager.switchIndex == 3 && !selfSwitch3)
        {
            taxiTrigger.SetActive(true);
            selfSwitch3 = true;
        }
        if (GameManager.switchIndex == 5 && !selfSwitch4)
        {
            SoundManager.Instance.outsideBgm.start();
            foreach (Transform child in GameObject.Find("GUI").transform)
            {
                child.gameObject.SetActive(true);
            }
            taxiTrigger.SetActive(false);
            selfSwitch4 = true;
        }
        if (GameManager.cameFromTaxi)
        {
            GameObject.Find("Player").transform.position = new Vector2(8.28f, -23.1f);
            GameManager.cameFromTaxi = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.Instance.completedDialogues.Contains(returnDialogue) && !selfSwitch2)
        {
            inReturnDialogue = false;
            GameManager.freezeInput = false;
            foreach (Transform child in GameObject.Find("GUI").transform)
            {
                child.gameObject.SetActive(true);
            }
            selfSwitch2 = true;
        }
        if (inReturnDialogue)
        {
            if (!selfSwitch5)
            {
                DialogueManager.Instance.Dialogue = returnDialogue;
                selfSwitch5 = true;
            }
            GameManager.freezeInput = true;
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Debug.Log("INTERACTION");
                DialogueManager.Instance.Next();
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractable : Interactable
{
    [Header("Dialogue")]
    public DialogueSO dialogue;

    public string interactionText = "try talking to me";


    private void Awake()
    {
        //if(text)
        //    text.text = interactionText;
    }

    public void Interact()
    {
        //base.Interact(item);
        Debug.Log("test");
        if (!GameManager.freezeInput)
        {
            DialogueManager.Instance.Dialogue = dialogue;
            GameManager.FreezeInput();
        } else
        {
            DialogueManager.Instance.Next();
        }
        
        
        //return true;
    }
}

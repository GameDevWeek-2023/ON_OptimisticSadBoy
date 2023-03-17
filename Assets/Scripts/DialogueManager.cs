using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using System;

public class DialogueManager : Singleton<DialogueManager>
{
    public static Action<int> EventDialogueTriggered;
    public static Action<int> EventDialogueFinished;
    public static Action EventRewardItem;

    public AudioClip clickSound;

    [SerializeField]
    private DialogueSO _dialogue;
    [SerializeField]
    private Image _characterImageLeftUI;
    [SerializeField]
    private Image _characterImageRightUI;
    [SerializeField]
    private TMP_Text _dialogueTextUI;
    [SerializeField]
    private RectTransform _dialogueUIWrapper;

    private int _dialogueItemIndexCurrent = 0;
    private int _dialogueItenIndexMax = 0;
    private Vector4 _alphaCharacterDisabled = new Vector4(1, 1, 1, 0);
    private Vector4 _alphaCharacterActive = new Vector4(1, 1, 1, 1);
    private Vector4 _alphaCharacterPassive = new Vector4(1, 1, 1, .35f);

    public List<DialogueSO> completedDialogues = new List<DialogueSO>();

    public GameObject audioManager;

    private void Start()
    {
        _dialogueTextUI.text = "";
        _characterImageLeftUI.color = _alphaCharacterDisabled;
        _characterImageRightUI.color = _alphaCharacterDisabled;
        //audioManager = GameObject.Find("AudioManager");
    }

    public DialogueSO Dialogue
    {
        get => _dialogue;
        set
        {
            // Already completed
            if (completedDialogues.Contains(value))
            {
                // Go to next Dialogue if possible
                if (value.nextDialogue)
                {
                    Dialogue = value.nextDialogue;
                }
                return;
            }
            
            // Does character have item already in hand?
            /*if (value.requiredItem && value.requiredItem == Inventory.Instance.GetItemInHand())
            {
                // remove item if needed
                if(value.removeRequiredItem)
                    InventoryManager.Instance.RemoveItem(value.requiredItem);
                
                // Add dialogue as completed
                completedDialogues.Add(value);
                // Go to next Dialogue if possible
                if (value.nextDialogue)
                {
                    Dialogue = value.nextDialogue;
                }
                return;
            }
            */
            
            _dialogue = value;
            
            
            ResetDialogueItemIndex();
            UpdateDialogueItemIndexMax();
            InitializeUI();
            UpdateUI();
            ShowDialogueUI();
            EventDialogueTriggered?.Invoke(_dialogue.GetInstanceID());
        }
    }

    private void ShowDialogueUI()
    {
        _dialogueUIWrapper.gameObject.SetActive(true);
    }

    private void HideDialogueUI()
    {
        _dialogueUIWrapper.gameObject.SetActive(false);
    }

    private void ToggleDialogueUI()
    {
        _dialogueUIWrapper.gameObject.SetActive(!_dialogueUIWrapper.gameObject.activeSelf);
    }

    private void ResetDialogueItemIndex()
    {
        _dialogueItemIndexCurrent = 0;
    }

    private void UpdateDialogueItemIndexMax()
    {
        
       //audioManager.GetComponent<AudioSource>().PlayOneShot(clickSound, 0.5f);
        _dialogueItenIndexMax = _dialogue.DialogueItemList.Count - 1;
        
    }

    private void NextDialogueItemIndex()
    {
        Debug.Log("NEXT");
        audioManager.GetComponent<AudioSource>().PlayOneShot(clickSound, 0.5f);
        _dialogueItemIndexCurrent++;
        Debug.Log(_dialogueItemIndexCurrent);
    }

    private bool IsDialogueFinished()
    {
        return (_dialogueItemIndexCurrent > _dialogueItenIndexMax) ? true : false;
    }

    private void InitializeUI()
    {
        _characterImageLeftUI.enabled = (_dialogue.StartImageLeft == null) ? false : true;
        _characterImageLeftUI.sprite = _dialogue.StartImageLeft;
        _characterImageLeftUI.color = _alphaCharacterActive;
        
        _characterImageRightUI.enabled = (_dialogue.StartImageRight == null) ? false : true;
        _characterImageRightUI.sprite = _dialogue.StartImageRight;
        _characterImageRightUI.color = _alphaCharacterActive;
 
        _dialogueTextUI.text = "";
    }

    private void UpdateUI()
    {
        DialogueItemStruct dialogueItem = _dialogue.DialogueItemList[_dialogueItemIndexCurrent];
        if(dialogueItem.Position == DialogueCharacterPosition.LEFT)
        {
            _characterImageLeftUI.enabled = (dialogueItem.Image == null) ? false : true;
            _characterImageLeftUI.sprite = dialogueItem.Image;
            _characterImageLeftUI.color = _alphaCharacterActive;
            _characterImageRightUI.color = _alphaCharacterPassive;
        }
        if (dialogueItem.Position == DialogueCharacterPosition.RIGHT)
        {
            _characterImageRightUI.enabled = (dialogueItem.Image == null) ? false : true;
            _characterImageRightUI.sprite = dialogueItem.Image;
            _characterImageRightUI.color = _alphaCharacterActive;
            _characterImageLeftUI.color = _alphaCharacterPassive;
        }
        _dialogueTextUI.text = dialogueItem.Text;
        /*
        // Handle Dialogue Item
        if(dialogueItem.rewardItems.Count > 0)
            HandleRewardItems(dialogueItem.rewardItems);
        */
        
        
        
        
        // ----------------
        
        NextDialogueItemIndex();
    }

    public void Next()
    {
        Debug.Log("debug");
        //if (context.phase != InputActionPhase.Performed) return;

        if(IsDialogueFinished())
        {
            Debug.Log("finish");
            CompleteDialogue(_dialogue);
            return;
        }

        UpdateUI();
    }

    public void CompleteDialogue(DialogueSO dialogue)
    {
        EventDialogueFinished?.Invoke(dialogue.GetInstanceID());
        HideDialogueUI();
        //HandleRewardItem();
        
        if(!dialogue.isLoop)
            completedDialogues.Add(dialogue);

        GameManager.Instance.UnfreezeInput();
    }
    /*
    void HandleRewardItems(List<ItemSO> items)
    {
        
        if (items.Count == 0) return;
        foreach (ItemSO item in items)
        {
            InventoryManager.Instance.InventoryList.Add(item);
        }
        EventRewardItem?.Invoke();
        
    }
    
    private void HandleRewardItem()
    {
        if (_dialogue.RewardItemList.Count == 0) return;
        
        HandleRewardItems(_dialogue.RewardItemList);
    }
    */
}
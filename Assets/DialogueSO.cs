using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "SO/DialogueSystem/Dialogue")]
public class DialogueSO : ScriptableObject
{
    
    [Header("Setup")]
    [SerializeField]
    private string _title;
    [SerializeField]
    [TextArea(2,5)]
    private string _description;
    [SerializeField]
    private Sprite _startImageLeft;
    [SerializeField]
    private Sprite _startImageRight;

    public AudioClip dialogueMusic;
    public AudioClip narratorSound;
    
    [Header("Dialogue")]
    [SerializeField]
    private List<DialogueItemStruct> _dialogueItemList = new List<DialogueItemStruct>();
    /*
    [Header("Finished")]
    [SerializeField]
    private List<ItemSO> _rewardItemList;
    */
    public bool isLoop = true;
    //public ItemSO requiredItem;
    //public bool removeRequiredItem = true;
    public DialogueSO nextDialogue;


    //public bool openSceneOnComplete = false;
    //public string sceneName;

    public bool isNarratorText = false;
    

    public string Title { get => _title; set => _title = value; }
    public string Description { get => _description; set => _description = value; }
    public Sprite StartImageLeft { get => _startImageLeft; private set => _startImageLeft = value; }
    public Sprite StartImageRight { get => _startImageRight; private set => _startImageRight = value; }
    //public List<ItemSO> RewardItemList { get => _rewardItemList; private set => _rewardItemList = value; }
    public List<DialogueItemStruct> DialogueItemList { get => _dialogueItemList; private set => _dialogueItemList = value; }
}
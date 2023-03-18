using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct DialogueItemStruct
{
    //[SerializeField]
    private DialogueCharacter _character;
    //[SerializeField]
    //private DialogueEventSO _event;
    [SerializeField]
    private DialogueCharacterPosition _position;
    [SerializeField]
    private Sprite _image;
    [SerializeField]
    [TextArea(3,10)]
    private string _text;

    //[HideInInspector]
    public List<ItemSO> rewardItems;

    public DialogueCharacter Character { get => _character; private set => _character = value; }
    //public DialogueEventSO Event { get => _event; private set => _event = value; }
    public DialogueCharacterPosition Position { get => _position; private set => _position = value; }
    public Sprite Image { get => _image; private set => _image = value; }
    public string Text { get => _text; private set => _text = value; }
}
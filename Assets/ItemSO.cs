using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "SO/ItemSystem/Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite sprite;
}

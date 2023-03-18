using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessControl : MonoBehaviour
{
    public Sprite[] happinessLevels;

    void Update()
    {
        GetComponent<Image>().sprite = happinessLevels[GameManager.happiness];
    }
}

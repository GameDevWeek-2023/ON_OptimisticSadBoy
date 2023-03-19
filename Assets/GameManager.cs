using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public static int happiness = 0;
    public static bool freezeInput = false;
    public static bool cameFromWakeUp = true;
    public static bool cameFromTaxi = false;
    public static bool backFromSchool = false;
    public static bool schoolReturn = false;
    public static bool killBettler = false;
    public static int switchIndex = 0;

    public static void FreezeInput()
    {
        freezeInput = true;
    }

    public static void UnfreezeInput()
    {
        freezeInput = false;
    }

    public static void UIOn()
    {
        GameObject.Find("UI").GetComponent<Image>().enabled = true;
        GameObject.Find("GUI/Head Right").GetComponent<Image>().enabled = true;
        GameObject.Find("GUI/Head Left").GetComponent<Image>().enabled = true;
    }

    public static void Reset()
    {
        GameManager.happiness = 0;
        GameManager.freezeInput = false;
        GameManager.cameFromWakeUp = true;
        GameManager.backFromSchool = false;
        GameManager.schoolReturn = false;
        GameManager.killBettler = false;
        GameManager.switchIndex = 0;
    }

}

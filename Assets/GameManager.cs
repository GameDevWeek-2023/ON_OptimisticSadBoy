using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public static bool freezeInput = false;
    public static bool cameFromWakeUp = true;
    public static bool backFromSchool = false;
    public static int switchIndex = 0;

    public static void FreezeInput()
    {
        freezeInput = true;
    }

    public static void UnfreezeInput()
    {
        freezeInput = false;
    }

}

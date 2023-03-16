using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public bool freezeInput = false;

    public void FreezeInput()
    {
        freezeInput = true;
    }

    public void UnfreezeInput()
    {
        freezeInput = false;
    }


}

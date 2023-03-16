using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public bool freezeInput = false;


    void Start()
    {
        SoundManager.Instance.houseBgm.start();
    }

    public void FreezeInput()
    {
        freezeInput = true;
    }

    public void UnfreezeInput()
    {
        freezeInput = false;
    }

    public void LoadHouseScene()
    {
        SoundManager.Instance.outsideBgm.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        SoundManager.Instance.houseBgm.start();
        SceneManager.LoadScene("Outside");
    }

    public void LoadOutsideScene()
    {        
        SoundManager.Instance.houseBgm.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        SoundManager.Instance.outsideBgm.start();
        SceneManager.LoadScene("Outside");
    }
    



}

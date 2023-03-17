using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public bool freezeInput = false;


    void Start()
    {
        
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
        SoundManager.Instance.outsideBgm.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        SoundManager.Instance.houseBgm.start();
        SoundManager.Instance.PlayDoorSound();
        SceneManager.LoadScene("House");
    }

    public void LoadOutsideScene()
    {        
        SoundManager.Instance.houseBgm.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        SoundManager.Instance.outsideBgm.start();
        SoundManager.Instance.PlayDoorSound();
        SceneManager.LoadScene("Hometown");
    }
    



}

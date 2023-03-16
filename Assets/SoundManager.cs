using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>

{

    public FMOD.Studio.EventInstance _houseBgm;
    public FMOD.Studio.EventInstance _outsideBgm;
    public FMOD.Studio.EventInstance _brainBgm;

    private static FMOD.Studio.EventInstance footstepEvent;

    public int terrain = 0;

    void Start()
    {
        _houseBgm = FMODUnity.RuntimeManager.CreateInstance("event:/Music/HouseBGM");
        _houseBgm.start();

        _outsideBgm = FMODUnity.RuntimeManager.CreateInstance("event:/Music/OutsideBGM");

        _brainBgm = FMODUnity.RuntimeManager.CreateInstance("event:/Music/BrainBGM");
    }

    
    void Update()
    {

    }

    public void PlayFootstepSound()
    {
        footstepEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Footsteps");

        switch (terrain)
        {
            case 6:
                footstepEvent.setParameterByName("Surface", 0);
                break;

            case 7:
                footstepEvent.setParameterByName("Surface", 1);
                break;

            case 8:
                footstepEvent.setParameterByName("Surface", 2);
                break;

            case 9:
                footstepEvent.setParameterByName("Surface", 3);
                break;
        }

        footstepEvent.start();
        footstepEvent.release();
    }






}

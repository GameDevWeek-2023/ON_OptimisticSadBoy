using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>

{

    public FMOD.Studio.EventInstance houseBgm;
    public FMOD.Studio.EventInstance outsideBgm;
    public FMOD.Studio.EventInstance brainBgm;
    public FMOD.Studio.EventInstance startBgm;

    private static FMOD.Studio.EventInstance footstepEvent;

    public int terrain = 0;

    void Start()
    {
        houseBgm = FMODUnity.RuntimeManager.CreateInstance("event:/Music/HouseBGM");
        //_houseBgm.start();

        outsideBgm = FMODUnity.RuntimeManager.CreateInstance("event:/Music/OutsideBGM");

        brainBgm = FMODUnity.RuntimeManager.CreateInstance("event:/Music/BrainBGM");

        startBgm = FMODUnity.RuntimeManager.CreateInstance("event:/Music/StartMenuBGM");
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

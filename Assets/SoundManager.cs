using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>

{

    public FMOD.Studio.EventInstance houseBgm;
    public FMOD.Studio.EventInstance outsideBgm;
    public FMOD.Studio.EventInstance brainBgm;
    public FMOD.Studio.EventInstance startBgm;
    public FMOD.Studio.EventInstance deepBgm;

    private static FMOD.Studio.EventInstance footstepEvent;

    private FMOD.Studio.EventInstance doorEvent;
    private FMOD.Studio.EventInstance busEvent;

    public FMOD.Studio.EventInstance taxiEvent;
    public FMOD.Studio.EventInstance chapterStartEvent;

    public int terrain = 0;

    void Start()
    {

        DontDestroyOnLoad(this.gameObject);

        houseBgm = FMODUnity.RuntimeManager.CreateInstance("event:/Music/HouseBGM");
        //_houseBgm.start();

        outsideBgm = FMODUnity.RuntimeManager.CreateInstance("event:/Music/OutsideBGM");
        //outsideBgm.start();

        brainBgm = FMODUnity.RuntimeManager.CreateInstance("event:/Music/BrainBGM");

        startBgm = FMODUnity.RuntimeManager.CreateInstance("event:/Music/StartMenuBGM");

        deepBgm = FMODUnity.RuntimeManager.CreateInstance("event:/Music/DeepBGM");

        taxiEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Taxi");
        
        chapterStartEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/ChapterStart");
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

    public void PlayDoorSound()
    {
        doorEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Door");
        doorEvent.start();
    }

    public void PlayBusSound()
    {
        busEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Bus");
        busEvent.start();
    }







}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{

    public ItemSO bread;
    public AudioClip failClip;
    public AudioSource source;
    public AudioClip removeItem;
    public GameObject bettler;
    public GameObject bus;
    public DialogueSO bettlerDialogue;

    public bool tookBread = false;
    public bool bettlerSpawn = false;
    public bool busGone = false;

    public void Update()
    {
        if (!tookBread && (SceneManager.GetActiveScene().name == "Hometown")) {
            //Debug.Log("TEST");
            if (DialogueManager.Instance._dialogue != null)
            {
                if (DialogueManager.Instance._dialogue.Title == "The Bettler TM")
                {
                    //Debug.Log("TEST2");
                    if (DialogueManager.Instance._dialogueItemIndexCurrent == 9)
                    {
                        //Debug.Log("TEST3");
                        InventoryManager.Instance.RemoveItem(bread);
                        source.PlayOneShot(removeItem, 0.7f);
                        tookBread = true;
                        GameManager.happiness++;
                    }
                }
            }
        }
        if (!bettlerSpawn && GameManager.backFromSchool && !GameManager.killBettler)
        {
            bettlerSpawn = true;
            bettler.SetActive(true);
            GameObject.Find("Bettler").GetComponent<DialogueInteractable>().dialogue = bettlerDialogue;
        }
        if (!busGone && !GameManager.backFromSchool)
        {
            busGone = true;
            bus.SetActive(true);
        }

    }

    public void LoadHouseScene()
    {
        if (GameManager.switchIndex >= 2)
        {
            GameManager.killBettler = true;
        }
        SoundManager.Instance.outsideBgm.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        SoundManager.Instance.houseBgm.start();
        SoundManager.Instance.PlayDoorSound();
        SceneManager.LoadScene("House");

    }

    public void LoadOutsideScene()
    {
        if (InventoryManager.Instance.inventory.Contains(bread))
        {
            SoundManager.Instance.houseBgm.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            SoundManager.Instance.outsideBgm.start();
            SoundManager.Instance.PlayDoorSound();
            SceneManager.LoadScene("Hometown");
        } else
        {
            GameObject.Find("SFX").GetComponent<AudioSource>().PlayOneShot(failClip);
        }        
    }

    public void LoadSchoolScene()
    {
        GameManager.backFromSchool = true;
        SoundManager.Instance.outsideBgm.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        SoundManager.Instance.PlayBusSound();
        foreach (Transform child in GameObject.Find("GUI").transform)
        {
            child.gameObject.SetActive(false);
        }
        StartCoroutine(Transition());
    }

    public void LoadTaxiScene()
    {
        //GameManager.backFromSchool = true;
        SoundManager.Instance.outsideBgm.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //SoundManager.Instance.PlayBusSound();
        foreach (Transform child in GameObject.Find("GUI").transform)
        {
            child.gameObject.SetActive(false);
        }
        GameManager.killBettler = true;
        GameManager.happiness++;
        StartCoroutine(Transition());
    }
    /*
    public void BackFromSchoolScene()
    {
        //SoundManager.Instance.deepBgm.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        SoundManager.Instance.PlayBusSound();
        StartCoroutine(Transition());
    }
    */
    public void LoadBrainScene()
    {
        //GameManager.backFromSchool = true;
        SoundManager.Instance.houseBgm.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        SoundManager.Instance.brainBgm.start();
        /*foreach (Transform child in GameObject.Find("GUI").transform)
        {
            child.gameObject.SetActive(false);
        }*/
        GameManager.switchIndex = 5;
        StartCoroutine(Transition());
    }



    IEnumerator Transition()
    {
        SceneManager.LoadScene("Black");
        yield return new WaitForSeconds(0.5f);
    }





}

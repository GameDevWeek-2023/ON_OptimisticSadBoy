using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    public ItemSO bread;
    public AudioClip failClip;
    public AudioSource source;
    public AudioClip removeItem;
    public GameObject bettler;
    public GameObject bus;

    public bool tookBread = false;
    public bool bettlerSpawn = false;
    public bool busGone = false;

    public void Update()
    {
        if (!tookBread && (SceneManager.GetActiveScene().name == "Hometown")) {
            Debug.Log("TEST");
            if (DialogueManager.Instance._dialogue != null)
            {
                if (DialogueManager.Instance._dialogue.Title == "The Bettler TM")
                {
                    Debug.Log("TEST2");
                    if (DialogueManager.Instance._dialogueItemIndexCurrent == 9)
                    {
                        Debug.Log("TEST3");
                        InventoryManager.Instance.RemoveItem(bread);
                        source.PlayOneShot(removeItem, 1f);
                        tookBread = true;
                    }
                }
            }
        }
        if (!bettlerSpawn && GameManager.backFromSchool)
        {
            bettlerSpawn = true;
            bettler.SetActive(true);
        }
        if (!busGone && !GameManager.backFromSchool)
        {
            busGone = true;
            bus.SetActive(true);
        }
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
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        SceneManager.LoadScene("Black");
        yield return new WaitForSeconds(0.5f);
    }





}

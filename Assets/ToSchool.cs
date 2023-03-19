using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToSchool : MonoBehaviour
{
    string[] sceneNames = { "WakeUp", "School", "Hometown", "Taxi", "Hometown", "Brainworld" , "StartMenu" };
    float[] switchTimes = { 4f, 5f, 5f, 0.5f, 2f, 5f };
    bool final = false;

    public GameObject[] titles;
    
    // Start is called before the first frame update
    void Start()
    {
        if (titles[GameManager.switchIndex] != null)
            titles[GameManager.switchIndex].SetActive(true);
        if (GameManager.switchIndex == 6)
        {
            GameManager.Reset();
            final = true;
        }
        if (GameManager.switchIndex == 0)
        {
            SoundManager.Instance.chapterStartEvent.start();
        }
        StartCoroutine(TransitionScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TransitionScene()
    {
        yield return new WaitForSeconds(switchTimes[GameManager.switchIndex]);
        if (final)
        {
            SceneManager.LoadScene("StartMenu");
        } else
        {
            SceneManager.LoadScene(sceneNames[GameManager.switchIndex]);
            GameManager.switchIndex++;
        }
    }
}

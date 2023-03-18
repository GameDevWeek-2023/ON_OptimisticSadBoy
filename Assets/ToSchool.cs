using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToSchool : MonoBehaviour
{
    string[] sceneNames = { "WakeUp", "School", "Hometown", "Taxi", "Hometown", "Brainworld" };
    float[] switchTimes = { 2f, 5f, 5f, 0.5f, 2f, 5f };
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TransitionScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TransitionScene()
    {
        yield return new WaitForSeconds(switchTimes[GameManager.switchIndex]);
        SceneManager.LoadScene(sceneNames[GameManager.switchIndex]);
        GameManager.switchIndex++;
    }
}

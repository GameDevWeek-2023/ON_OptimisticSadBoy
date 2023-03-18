using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToSchool : MonoBehaviour
{
    string[] sceneNames = { "WakeUp", "School" };
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TransitionScene(5.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TransitionScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneNames[GameManager.switchIndex]);
        GameManager.switchIndex++;
    }
}

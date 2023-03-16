using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    void Start()
    {
        SoundManager.Instance.startBgm.start();
    }

    public void StartGame()
    {
        StartCoroutine(SceneTransition());
    }

    public void OpenOptions()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator SceneTransition()
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("House");
        SoundManager.Instance.startBgm.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}

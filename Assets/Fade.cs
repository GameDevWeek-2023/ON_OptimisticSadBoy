using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    SpriteRenderer rend;
    public float speed = 0.05f;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        rend = GetComponent<SpriteRenderer>();
    }

    public void In(float speedIn)
    {
        speed = speedIn;
        StartCoroutine(FadeIn());
    }

    public void Out(float speedOut)
    {
        speed = speedOut;
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeIn()
    {
        Debug.Log("fadein");
        for (float i = 0f; i <= 255f; i += 0.01f)
        {
            Color c = rend.material.color;
            c.a = i;
            rend.material.color = c;
            yield return new WaitForSeconds(speed);
        }
    }

    public IEnumerator FadeOut()
    {
        for (float i = 255f; i >= 0f; i -= 0.01f)
        {
            Color c = rend.material.color;
            c.a = i;
            rend.material.color = c;
            yield return new WaitForSeconds(speed);
        }
    }
}

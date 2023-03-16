using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{

    public Sprite closedSprite;
    public Sprite openSprite;
    public AudioSource source;
    public AudioClip openSound;
    public AudioClip closeSound;
    public float openX = 6.6f;
    public float closedX = 8.47f;

    // Start is called before the first frame update
    public void Open()
    {
        Debug.Log("test");
        GetComponent<SpriteRenderer>().sprite = openSprite;
        transform.localPosition = new Vector2(openX, transform.localPosition.y);
        GetComponent<Renderer>().sortingOrder = 2;
        source.PlayOneShot(openSound);
    }

    // Update is called once per frame
    public void Close()
    {
        GetComponent<SpriteRenderer>().sprite = closedSprite;
        transform.localPosition = new Vector2(closedX, transform.localPosition.y);
        GetComponent<Renderer>().sortingOrder = 4;
        source.PlayOneShot(closeSound);
    }
}

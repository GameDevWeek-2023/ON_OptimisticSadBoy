using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BrainScene : MonoBehaviour
{

    public GameObject demon;
    public DialogueSO brainStartDialogue;
    public bool selfSwitch = false;
    public bool inBrainDialogue = false;
    public ItemSO necklace;
    public SpriteRenderer necklaceSprite;
    public AudioClip failSound;
    public AudioClip niceSound;
    private bool selfSwitch2 = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().moveSpeed = 3 + 3 * GameManager.happiness;        
        inBrainDialogue = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.Instance.completedDialogues.Contains(brainStartDialogue) && !selfSwitch)
        {
            inBrainDialogue = false;
            GameManager.freezeInput = false;
            foreach (Transform child in GameObject.Find("GUI").transform)
            {
                child.gameObject.SetActive(true);
            }
            demon.SetActive(true);
            selfSwitch = true;
        }
        if (inBrainDialogue)
        {
            if (!selfSwitch2)
            {
                DialogueManager.Instance.Dialogue = brainStartDialogue;
                selfSwitch2 = true;
            }
            GameManager.freezeInput = true;
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Debug.Log("INTERACTION");
                DialogueManager.Instance.Next();
            }
        }
    }

    public void Finale()
    {
        //GameManager.backFromSchool = true;
        if (InventoryManager.Instance.inventory.Contains(necklace))
        {
            InventoryManager.Instance.inventory.Remove(necklace);
            SoundManager.Instance.brainBgm.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            GameObject.Find("SFX").GetComponent<AudioSource>().PlayOneShot(niceSound);
            foreach (Transform child in GameObject.Find("GUI").transform)
            {
                child.gameObject.SetActive(false);
            }
            Destroy(GameObject.Find("GUI"));
            Destroy(GameObject.Find("AudioManager"));
            necklaceSprite.sprite = necklace.sprite;
            GameManager.FreezeInput();
            GameManager.switchIndex = 6;
            StartCoroutine(Transition());
        }
       else
        {
            GameObject.Find("SFX").GetComponent<AudioSource>().PlayOneShot(failSound);
        }
        
        
        //StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Black");
    }


}

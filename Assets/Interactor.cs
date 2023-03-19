using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{

    public LayerMask interactableLayerMask;
    public LayerMask demonLayerMask;
    UnityEvent onInteract;
    InputAction controls;
    public AudioClip slash;
    Vector3 footOffset = new Vector3(0, -2, 0);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D[] hits;
        //Debug.Log(transform.position);
        hits = Physics2D.RaycastAll(transform.position + footOffset, Vector3.forward, 2f, interactableLayerMask, 0.99f, 1.01f);
        if (hits.Length > 0)
        {
            //Debug.Log("interact?");
            if (hits[0].collider.GetComponent<Interactable>() != false) {
                onInteract = hits[0].collider.GetComponent<Interactable>().onInteract;
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    Debug.Log("INTERACTION");
                    onInteract?.Invoke();
                }
            }
            

        }
        if (SceneManager.GetActiveScene().name == "Brainworld")
        {

            hits = Physics2D.RaycastAll(transform.position + footOffset, Vector3.forward, 2f, demonLayerMask, 0.99f, 1.01f);
            if (hits.Length > 0)
            {
                GameManager.Reset();
                GameObject.Find("SFX").GetComponent<AudioSource>().PlayOneShot(slash);
                foreach (Transform child in GameObject.Find("GUI").transform)
                {
                    child.gameObject.SetActive(false);
                }
                Destroy(GameObject.Find("GUI"));
                Destroy(GameObject.Find("AudioManager"));
                SoundManager.Instance.brainBgm.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                StartCoroutine(Transition());                
            }
        }
    }


    IEnumerator Transition()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("StartMenu");
    }

}

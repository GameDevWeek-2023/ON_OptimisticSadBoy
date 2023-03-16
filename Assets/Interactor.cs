using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{

    public LayerMask interactableLayerMask;
    UnityEvent onInteract;
    InputAction controls;
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
                    onInteract.Invoke();
                }
            }
            

        }
    }

}

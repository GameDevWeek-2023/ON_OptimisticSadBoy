using UnityEngine;
using UnityEngine.Events;

public class DoorCollider : MonoBehaviour
{
    public UnityEvent onOpen;
    public UnityEvent onClose;

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Schlafzimmertür offen!");
        onOpen.Invoke();
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        //Debug.Log("Schlafzimmertür geschlossen!");
        onClose.Invoke();
    }
}

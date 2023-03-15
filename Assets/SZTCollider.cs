using UnityEngine;

public class SZTCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("Schlafzimmertür offen!");
    }
    void OnTriggerExit2D(Collider2D collider){
        Debug.Log("Schlafzimmertür geschlossen!");

    }
}

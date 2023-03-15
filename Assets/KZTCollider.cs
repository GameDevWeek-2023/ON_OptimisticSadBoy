using UnityEngine;

public class KZTCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("Kinderzimmertür offen!");
    }
    void OnTriggerExit2D(Collider2D collider){
        Debug.Log("Kinderzimmertür geschlossen!");

    }
}

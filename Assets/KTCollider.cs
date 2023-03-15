using UnityEngine;

public class KTCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("Küchentür offen!");
    }
    void OnTriggerExit2D(Collider2D collider){
        Debug.Log("Küchentür geschlossen!");

    }
}

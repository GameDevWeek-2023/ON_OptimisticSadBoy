using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundCheckDoor : MonoBehaviour
{

    public float playerYThreshold;
    public GameObject player;
    public Renderer renderer;

    void FixedUpdate()
    {
        if (player.transform.position.y > playerYThreshold)
        {
            renderer.sortingOrder = 5;
        } else
        {
            renderer.sortingOrder = 2;
        }
    }
}

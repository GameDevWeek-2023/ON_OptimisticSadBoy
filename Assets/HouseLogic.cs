using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.cameFromWakeUp)
        {
            GameManager.cameFromWakeUp = false;
            GameObject.Find("Player").transform.position = new Vector2(4.047618f, -15.33084f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

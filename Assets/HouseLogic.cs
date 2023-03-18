using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseLogic : MonoBehaviour
{

    public GameObject bread;
    // Start is called before the first frame update
    void Start()
    {
        if (!GameManager.backFromSchool)
        {
            GameObject.Find("Sleep").SetActive(false);
        }
        if (GameManager.cameFromWakeUp)
        {
            bread.SetActive(true);
            //GameObject.Find("GUI").SetActive(true);
            foreach (Transform child in GameObject.Find("GUI").transform)
            {
                child.gameObject.SetActive(true);
            }
            GameObject.Find("Player").transform.position = new Vector2(4.047618f, -15.33084f);
            GameManager.cameFromWakeUp = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

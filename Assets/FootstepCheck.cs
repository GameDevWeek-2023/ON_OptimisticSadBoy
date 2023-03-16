using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepCheck : MonoBehaviour
{
    void Update()
    {
        RaycastHit2D[] _hits = Physics2D.RaycastAll(transform.position, Vector3.forward, 1.0f);
        //Debug.Log(transform.position);
        if (_hits.Length > 0)
        {
            SoundManager.Instance.terrain = _hits[0].transform.gameObject.layer;
        }
        //Debug.Log(terrain);
        //Debug.Log(_hits.Length);
    }
}

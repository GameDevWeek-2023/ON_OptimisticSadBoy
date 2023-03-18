using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Takes a handles input and movement for a player character
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public float moveSpeed = 5f;
    public InputAction playerControls;

    Vector2 moveDirection = Vector2.zero;

    Vector3 footOffset = new Vector3(0, -2, 0);

    private void OnEnable(){
        playerControls.Enable();
    }

    private void OnDisable(){
        playerControls.Disable();
    }

    void Update(){

        if (!GameManager.freezeInput)
        {
            CheckTerrain();

            moveDirection = playerControls.ReadValue<Vector2>();

            animator.SetFloat("Horizontal", moveDirection.x);
            animator.SetFloat("Vertical", moveDirection.y);

            animator.SetFloat("Speed", moveDirection.sqrMagnitude);

            if (animator.GetFloat("Speed") != 0)
            {
                animator.SetFloat("LastHorizontal", animator.GetFloat("Horizontal"));
                animator.SetFloat("LastVertical", animator.GetFloat("Vertical"));
            }
        } else
        {
            animator.SetFloat("Speed", 0);
        }
        
    }

    private void FixedUpdate(){
        if (!GameManager.freezeInput)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        } else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    public void OnStep()
    {
        SoundManager.Instance.PlayFootstepSound();
    }

    private void CheckTerrain()
    {
        RaycastHit2D[] _hits = Physics2D.RaycastAll(transform.position + footOffset, Vector3.forward, 1.0f);
        //Debug.Log(transform.position + footOffset);
        if (_hits.Length > 1)
        {
            SoundManager.Instance.terrain = _hits[1].transform.gameObject.layer;
        }
        //Debug.Log(terrain);
        //Debug.Log(_hits.Length);
    }
}

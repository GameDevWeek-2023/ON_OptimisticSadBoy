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

    private void OnEnable(){
        playerControls.Enable();
    }

    private void OnDisable(){
        playerControls.Disable();
    }

    void Update(){
        moveDirection = playerControls.ReadValue<Vector2>();

        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);

        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        if(animator.GetFloat("Speed") != 0){
            animator.SetFloat("LastHorizontal", animator.GetFloat("Horizontal"));
            animator.SetFloat("LastVertical", animator.GetFloat("Vertical"));
        }
    }

    private void FixedUpdate(){
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonMovement : MonoBehaviour
{
    public GameObject playerObj = null;
    public int detectRange = 10;
    public bool alive = true;
    public float MovementSpeed = 5f;
    public Rigidbody2D rb;
    public float moveSmooth = 0.8f;
    public Animator anim; 
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    public Vector2 smoothVelocity;
    void Start()
    {
        //If you want to find it by NAME. For t$$anonymous$$s you have to make sure you only have 1 object named "Player".
         if (playerObj == null)
             playerObj = GameObject.Find("Player");
 
         //If you want to find it by TAG. For t$$anonymous$$s you have to make sure you give your player object the tag "Player".
         if (playerObj == null)
             playerObj = GameObject.FindGameObjectWithTag("Player");
 
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate(){
        bool inRange = (playerObj.transform.position - this.transform.position).sqrMagnitude <= detectRange * detectRange;
        if(inRange == true && alive){
            Vector2 moveDir = (playerObj.transform.position - this.transform.position).normalized;
            Vector2 moveDirSpeed = moveDir * this.MovementSpeed;
            this.rb.velocity = Vector2.SmoothDamp(
                this.rb.velocity,
                moveDirSpeed.normalized * this.MovementSpeed,
                ref this.smoothVelocity,
                this.moveSmooth
            );
        }
        else if (inRange == false || !alive) { this.rb.velocity = Vector2.zero; }
        anim.SetFloat("Speed", rb.velocity.magnitude);
        if (rb.velocity.x > 0){
            sprite.flipX = true;
        }
        else if (rb.velocity.x < 0){
            sprite.flipX = false;
        }
    }
}

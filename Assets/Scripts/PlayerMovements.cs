using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [Header("outside classes")]
    public Rigidbody2D body;
    //public CameraFollow cam;
    //public Animator animator;
    public SpriteRenderer spriteRenderer;

    [Header("Player abilities")]
    public float powerJump;
    public float moveSpeed;
    public float dashPower;

    private bool canWalk = true;
    private bool canJump = true;
    private bool canFastFall = true;
    private bool direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentVelocity = new Vector2(0, body.velocity.y);

        //goes back to idle animation
        //animator.ResetTrigger("isWalking");
        //animator.ResetTrigger("isFalling");
        //animator.ResetTrigger("isJumping");

        //walk right
        if (Input.GetKey(KeyCode.D) && canWalk)
        {
            currentVelocity += new Vector2(moveSpeed, 0);
            //animator.SetTrigger("isWalking"); //animation
            spriteRenderer.flipX = false;
            direction = true;
        }

        //walk left
        if (Input.GetKey(KeyCode.A) && canWalk)
        {
            currentVelocity += new Vector2(-moveSpeed, 0);
            //animator.SetTrigger("isWalking"); //animation
            spriteRenderer.flipX = true;
            direction = false;
        }

        body.velocity = currentVelocity;

        //jump

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            //animator.SetTrigger("isJumping");
            body.AddForce(new Vector2(0, 1) * powerJump);
            canJump = false;
            canFastFall = true;
        }

        if (Input.GetKeyDown(KeyCode.S) && canFastFall)
        {
            body.AddForce(new Vector2(0, -1) * powerJump);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
            canFastFall = false;
        }
    }

    
}

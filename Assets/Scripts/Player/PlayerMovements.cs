using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [Header("outside classes")]
    public Rigidbody2D body;
    //public CameraFollow cam;
    //public Animator animator;
    private SpriteRenderer spriteRenderer;
    public GameObject axeHitbox;
    public PlayerRotation axeActions;
    public Animator animator;
    public Life playerLife;

    [Header("Player abilities")]
    public float powerJump;
    public float moveSpeed;
    public int strength = 1;
    public int rollPower;

    [Header("Don't touch")]
    public bool direction;
    public bool attackUp;
    private bool canWalk = true;
    private bool canJump = true;

    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 currentVelocity = new Vector2(0, body.velocity.y);
        //goes back to idle animation
        animator.ResetTrigger("isWalking");
        animator.ResetTrigger("isFalling");
        animator.ResetTrigger("isJumping");
        animator.ResetTrigger("isRolling");
        animator.ResetTrigger("isHit");
        animator.ResetTrigger("isAttacking");
        animator.ResetTrigger("isAttackingUp");

        //walk right
        if (Input.GetKey(KeyCode.D) && canWalk)
        {
            currentVelocity += new Vector2(moveSpeed, 0);
            animator.SetTrigger("isWalking"); //animation
            direction = false;
        }

        //walk left
        if (Input.GetKey(KeyCode.A) && canWalk)
        {
            currentVelocity += new Vector2(-moveSpeed, 0);
            animator.SetTrigger("isWalking"); //animation
            direction = true;
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.LeftControl) && canJump)
        {
            animator.SetTrigger("isRolling");
            body.AddForce(new Vector2(1, 0) * rollPower);
            direction = false;
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.LeftControl) && canJump)
        {
            animator.SetTrigger("isRolling");
            
            body.AddForce(new Vector2(-1, 0) * rollPower);
            direction = true;
        }

        spriteRenderer.flipX = direction;
        body.velocity = currentVelocity;

        //jump

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            animator.SetTrigger("isJumping");
            body.AddForce(new Vector2(0, 1) * powerJump);
            canJump = false;
        }

        if (Input.GetKeyDown(KeyCode.S) && !canJump)
        {
            body.AddForce(new Vector2(0, -1) * powerJump);
        }

        if (body.velocity.y < 0)
        {
            animator.SetTrigger("isFalling");
        }


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(PlayerAttack());
        }

    }

    private IEnumerator PlayerAttack() 
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        axeHitbox.SetActive(true);
        axeActions.Attack(mousePosition);
        if(attackUp)
            animator.SetTrigger("isAttackingUp");
        else
            animator.SetTrigger("isAttacking");
        yield return new WaitForSeconds(.2f);
        attackUp = false;
        axeHitbox.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.ResetTrigger("isFalling");
            canJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Sword")
        {
            playerLife.TakeDamage(1);
        }
    }


}

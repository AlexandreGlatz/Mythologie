using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("External classes")]
    public Rigidbody2D body;
    public GameObject player;
    public PlayerMovements playerBehaviour;
    public GameObject swordHitbox;
    public EnemyWeapon swordActions;
    public Animator animator;
    public Life enemyLife;

    [Header("enemyAttributes")]
    public int strength = 1;
    public float powerJump;
    public float moveSpeed;
    public float runSpeed;

    [Header("Don't touch")]
    public bool isInRange = false;
    public bool isInRunRange = false;
    public bool direction;
    public bool canJump;
    public bool attackUp;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 currentVelocity = new Vector2(0, body.velocity.y);
        //goes back to idle animation
        animator.ResetTrigger("isWalking");

        //walk right

        if(player.transform.position.x + 2> gameObject.transform.position.x && isInRunRange)
        {
            currentVelocity += new Vector2(runSpeed, 0);
            animator.SetTrigger("isWalking"); //animation
            direction = false;
        }
        if (player.transform.position.x - 2> gameObject.transform.position.x)
        {
            currentVelocity += new Vector2(moveSpeed, 0);
            animator.SetTrigger("isWalking"); //animation
            direction = false;
        }
        

        //walk left
        if (player.transform.position.x +2 < gameObject.transform.position.x)
        {
            currentVelocity += new Vector2(-moveSpeed, 0);
            animator.SetTrigger("isWalking"); //animation
            direction = true;
        }
        

        spriteRenderer.flipX = direction;
        body.velocity = currentVelocity;

        //jump

        if (isInRange && Random.Range(0, 2) == 1)
        {
            //animator.SetTrigger("isJumping");
            body.AddForce(new Vector2(0, 1) * powerJump);
            canJump = false;
        }

        else if (isInRange)
        {
            StartCoroutine(EnemyAttack());
        }
    }

    private IEnumerator EnemyAttack()
    {
        swordHitbox.SetActive(true);
        swordActions.Attack(player.transform.position);
        if(attackUp)
            animator.SetTrigger("isAttacking");
        else
           animator.SetTrigger("isAttacking");
        yield return new WaitForSeconds(.2f);
        swordHitbox.SetActive(false);
        isInRange = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Axe")
        {
            enemyLife.TakeDamage(playerBehaviour.strength);
        }
    }

} 


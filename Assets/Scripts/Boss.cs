using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Boss : MonoBehaviour
{
    [Header("External classes")]
    public Life bossLife;
    public GameObject boss;
    public Rigidbody2D body;
    public GameObject player;
    public PlayerMovements playerBehaviour;
    public GameObject swordHitbox;
    public BossWeapon swordActions;
    public Animator animator;
    public EnemyBehaviour enemyBehaviour;

    [Header("Boss attributes")]
    public string bossName;
    public int strength = 1;
    public float powerJump;
    public float moveSpeed;
    public float runSpeed;
    public float dashSpeed;

    [Header("Don't touch")]
    public bool isInRange = false;
    public bool isInRunRange = false;
    public bool isInDashRange = false;
    public bool direction;
    public bool attackUp;
    public bool callMinions;

    private bool canMove;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            
            Vector2 currentVelocity = new Vector2(0, body.velocity.y);
            //goes back to idle animation
            animator.ResetTrigger("isWalking");
            animator.ResetTrigger("isAttacking");
            animator.ResetTrigger("isAttackingUp");
            //walk right

            if (player.transform.position.x + 2 > gameObject.transform.position.x && isInRunRange)
            {
                currentVelocity += new Vector2(runSpeed, 0);
                animator.SetTrigger("isWalking"); //animation
                direction = false;
            }
            if (player.transform.position.x - 2 > gameObject.transform.position.x)
            {
                currentVelocity += new Vector2(moveSpeed, 0);
                animator.SetTrigger("isWalking"); //animation
                direction = false;
            }


            //walk left
            if (player.transform.position.x + 2 < gameObject.transform.position.x)
            {
                currentVelocity += new Vector2(-moveSpeed, 0);
                animator.SetTrigger("isWalking"); //animation
                direction = true;
            }

            spriteRenderer.flipX = direction;
            //dash
            if (isInDashRange && direction)
            {
                currentVelocity += new Vector2(-dashSpeed, 0);
                animator.SetTrigger("dashAttack"); //animation
            }

            if (isInDashRange && !direction)
            {
                currentVelocity += new Vector2(dashSpeed, 0);
                animator.SetTrigger("dashAttack"); //animation
                isInDashRange = false;
            }

            if (callMinions)
            {
                animator.SetTrigger("isCallingMinions");
                enemyBehaviour.SpawnMob(2);
                callMinions = false;
            }
            spriteRenderer.flipX = direction;
            body.velocity = currentVelocity;

            if (isInRange)
            {
                StartCoroutine(BossAttack());
            }
        }
    }

    private IEnumerator BossAttack()
    {
        swordHitbox.SetActive(true);
        swordActions.Attack(player.transform.position);
        if (attackUp)
            animator.SetTrigger("isAttackingUp");
        else
            animator.SetTrigger("isAttacking");
        attackUp = false;
        yield return new WaitForSeconds(1);
        swordHitbox.SetActive(false);
        isInRange = false;
    }
    public void StartBossFight()
    {
        canMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Axe")
        {
            bossLife.TakeDamage(playerBehaviour.strength);
        }
    }
}

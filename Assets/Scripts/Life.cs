using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [Header("Outside classes")]
    public Collider2D[] hitCollision;
    public Collider2D hittedCollision;
    public PlayerMovements player;
    private SpriteRenderer spriteRenderer;

    [Header("Life attributes")]
    public int healthPoint;
    private int initHealthPoint;
    public bool isPlayer;

    [Header("Don't touch")]
    public bool isInvincible;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initHealthPoint = healthPoint;
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            healthPoint -= damage;
            if (healthPoint < 0)
            {
                Death();
            }

            StartCoroutine(Invincibility());

        }
        else
        {
            StartCoroutine(Blink());
            foreach (Collider2D collider in hitCollision)
            {
                Physics2D.IgnoreCollision(collider, hittedCollision, true); // ignore collision with mob
            }
            
        }
    }

    public IEnumerator Blink()
    {
        for (int i = 0; i < 3; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
    }
    public void Death()
    {
        if (isPlayer)
        {
            StartCoroutine(Die());
        }
        else
        {
            StartCoroutine(MobDeath());
            Destroy(gameObject);
        }
    }

    public IEnumerator Die()
    {
        //animator.SetTrigger("isDead");
        yield return new WaitForSeconds(.3f);
        gameObject.transform.position = new Vector3(-10, 0.5f, 0);
        healthPoint = initHealthPoint;
    }
    public IEnumerator MobDeath()
    {
        //animator.SetTrigger("isDead");
        yield return new WaitForSeconds(.3f);

        Destroy(gameObject);
    }

    public IEnumerator Invincibility()
    {
        isInvincible = true;

        yield return new WaitForSeconds(2);

        isInvincible = false;
        foreach (Collider2D collider in hitCollision)
        {
            Physics2D.IgnoreCollision(collider, hittedCollision, false);
        }
        
    }
}


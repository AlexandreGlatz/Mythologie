using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyBehaviour enemyBehaviour;
    public int mobAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            enemyBehaviour.SpawnMob(mobAmount);
        }
    }

}

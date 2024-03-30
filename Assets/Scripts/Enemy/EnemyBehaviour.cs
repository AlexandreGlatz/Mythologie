using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour
{
    [Header("External classes")]
    public Enemy enemyPrefab;
    public GameObject player;
    public PlayerMovements playerMovements;
    private int randomspawn;
    private int currentIndex = 0;
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMob(int amount)
    {
        for(int i = 0; i < amount; i++) 
        {
            randomspawn = Random.Range(0, 2);
            if (randomspawn > 0)
            {
                Enemy tempEnemy = Instantiate(enemyPrefab, new Vector3(player.transform.position.x + 10, .5f, 0), Quaternion.identity);
                playerMovements.playerLife.hitCollision[i + currentIndex] = tempEnemy.gameObject.GetComponent<Collider2D>();
            }
            else
            {
                Enemy tempEnemy = Instantiate(enemyPrefab, new Vector3(player.transform.position.x - 10, .5f, 0), Quaternion.identity);
                playerMovements.playerLife.hitCollision[i + currentIndex] = tempEnemy.gameObject.GetComponent<Collider2D>();
            }
            currentIndex++;
        }
    }
}

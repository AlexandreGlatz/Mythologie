using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject entity;
    public Enemy movements;

    private bool right;
    private bool left;
    private bool up;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack(Vector3 thingToAimAt)
    {
        up = thingToAimAt.y > entity.transform.position.y + 0.5;
        right = thingToAimAt.x > entity.transform.position.x;
        left = thingToAimAt.x < entity.transform.position.x;
        if (up && right)
        {
            transform.position = new Vector3(entity.transform.position.x + 0.5f, entity.transform.position.y + 0.3f, 0);
            transform.localScale = new Vector3(2.5f, 2, 1);
        }

        else if (up && left)
        {
            transform.position = new Vector3(entity.transform.position.x - 0.5f, entity.transform.position.y + 0.3f, 0);
            transform.localScale = new Vector3(2.5f, 2, 1);
        }

        else if (right)
        {
            transform.position = new Vector3(entity.transform.position.x + 1.5f, entity.transform.position.y, 0);
            transform.localScale = new Vector3(0.2f, 2, 1);
            movements.direction = false;
        }

        else if (left)
        {
            transform.position = new Vector3(entity.transform.position.x - 1.5f, entity.transform.position.y, 0);
            transform.localScale = new Vector3(0.2f, 2, 1);
            movements.direction = true;
        }
    }
}

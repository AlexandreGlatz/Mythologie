using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public GameObject entity;
    public PlayerMovements movements;

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
            transform.localScale = new Vector3(1, .5f, 1);
            movements.attackUp = true;
            movements.direction = false;
        }

        else if (up && left)
        {
            transform.position = new Vector3(entity.transform.position.x - 0.5f, entity.transform.position.y + 0.3f, 0);
            transform.localScale = new Vector3(1, .5f, 1);
            movements.attackUp = true;
            movements.direction = true;
        }

        else if (right)
        {
            transform.position = new Vector3(entity.transform.position.x + 1.5f, entity.transform.position.y, 0);
            transform.localScale = new Vector3(0.01f, 0.5f, 1);
            movements.direction = false;
        }

        else if (left)
        {
            transform.position = new Vector3(entity.transform.position.x - 1.5f, entity.transform.position.y, 0);
            transform.localScale = new Vector3(0.01f, 0.5f, 1);
            movements.direction = true;
        }
    }
}

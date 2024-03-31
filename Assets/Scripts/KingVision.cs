using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingVision : MonoBehaviour
{
    public Boss boss;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            boss.isInDashRange = true;
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        boss.callMinions = true;
    //    }
    //}

}

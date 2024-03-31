using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightsOff : MonoBehaviour
{
    [Header("External classes")]
    public GameObject fire;
    public Light2D lampLight;
    public bool isLastLight;
    public Boss boss;
    public Light2D moonLight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            lampLight.intensity = 0;
            if (!isLastLight)
            {
                Destroy(fire);
                Destroy(gameObject);
            }
            else 
            {
                StartCoroutine(StartFight());
            }
        }
        
    }

    public IEnumerator StartFight()
    {
        yield return new WaitForSeconds(3);
        moonLight.gameObject.SetActive(true);
        boss.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        boss.StartBossFight();
        Destroy(lampLight);
        Destroy(gameObject);
    }
}

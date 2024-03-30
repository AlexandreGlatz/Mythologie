using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightsOff : MonoBehaviour
{
    [Header("External classes")]
    public Light2D lampLight;
    public bool isLastLight;
    public Boss boss;
    public Light2D moonLight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            if (!isLastLight)
            {
                lampLight.intensity = 0;
                Destroy(lampLight);
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
        print("1");
        yield return new WaitForSeconds(3);
        print("2");
        moonLight.gameObject.SetActive(true);
        boss.gameObject.SetActive(true);
        lampLight.intensity = 0;
        Destroy(lampLight);
        Destroy(gameObject);
    }
}

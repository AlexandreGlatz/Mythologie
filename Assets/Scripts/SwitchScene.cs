using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SwitchScene : MonoBehaviour
{
    [Header("External classes")]
    public GameObject PlainBg;
    public GameObject ParisBg;
    public Light2D globalLight;
    public bool lightAcivated = true;
    private bool plainScene = true;
    private bool parisScene = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlainBg.SetActive(plainScene);
        ParisBg.SetActive(parisScene);
        if(lightAcivated)
        {
            globalLight.intensity = 1;
        }
        else
        {
            globalLight.intensity = 0;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            lightAcivated = false;
            plainScene = !plainScene;
            parisScene = !parisScene;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lights : MonoBehaviour
{
    [Header("External classes")]
    public Light2D lampLight;
    private float initIntensity;
    // Start is called before the first frame update
    void Start()
    {
        initIntensity = lampLight.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Flicker());
    }

    public IEnumerator Flicker()
    {
        lampLight.intensity = initIntensity - .5f;
        yield return new WaitForSeconds(Random.Range(.2f,1.0f));
        lampLight.intensity = initIntensity + .5f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lights : MonoBehaviour
{
    [Header("External classes")]
    public Light2D lampLight;
    private float initRange;
    // Start is called before the first frame update
    void Start()
    {
        initRange = lampLight.pointLightOuterRadius;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Flicker());
    }

    public IEnumerator Flicker()
    {
        lampLight.pointLightOuterRadius = initRange - 1f;
        yield return new WaitForSeconds(Random.Range(.2f,1.0f));
        lampLight.intensity = initRange + 1f;
    }
}

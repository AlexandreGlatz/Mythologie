using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBAck : MonoBehaviour
{
    LoadingScreen loadingScreen;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Back());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Back()
    {
        yield return new WaitForSeconds(21);
        loadingScreen.LoadScene(0);
    }
}

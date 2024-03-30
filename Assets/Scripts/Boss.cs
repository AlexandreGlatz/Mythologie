using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Boss : MonoBehaviour
{
    [Header("External classes")]
    public Life bossLife;
    public GameObject boss;
    

    [Header("Boss attributes")]
    public string bossName;

    private int startLife;
    private int nextAction;
    // Start is called before the first frame update
    void Start()
    {
        startLife = bossLife.healthPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}

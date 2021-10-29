using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float Tempo;
    public GameObject Test;

    float conta;

    void NewEnemy()
    {
        if (!GameObject.Find("Test"))
        {
            conta += Time.deltaTime;
            if (conta > Tempo)
            {
                Instantiate(Test);
                conta = 0;
            }
        }
    }

    void FixedUpdate()
    {
        NewEnemy();
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private float time = 0;
    private float maxTime = 0.5f;

    void Update()//instancia un meteorito cada x tiempo y mete la posicion en lista
    {
        time += Time.deltaTime;
        if (time >= maxTime)
        {
            Destroy(gameObject);
        }
    }
}

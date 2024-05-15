using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takelifes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool lifeRecuperated = GameManager.instance.ReturnLifes();
        if(lifeRecuperated)
        {
            Destroy(this.gameObject);
        }
        
    }
}

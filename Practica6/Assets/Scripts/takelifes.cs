using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takelifes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.instance.ReturnLifes();
        Destroy(this.gameObject);
    }
}

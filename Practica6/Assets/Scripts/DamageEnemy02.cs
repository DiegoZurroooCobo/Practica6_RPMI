using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy02 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth)
            {
                playerHealth.LoseLifes();
                //Destroy(collision.gameObject);
            }
        }
    }
}

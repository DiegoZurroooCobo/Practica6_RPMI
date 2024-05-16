using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemey01 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.GetComponent<PlayerMovement>())
            {
                if (collision.GetContact(0).normal.y <= -0.9) // Si saltas encima del Enemigo pasa esto:
                {

                    Debug.Log("SaltasteEncimaMia");

                }
                else
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
}

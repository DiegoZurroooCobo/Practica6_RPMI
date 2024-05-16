using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() && Input.GetKeyDown(KeyCode.E))
        {
            print("puerta");
            GameManager.instance.LoadScene("BossLevel");
        }
    }
}

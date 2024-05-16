using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static points;

public class Puntuation : MonoBehaviour
{
    private GameObject Efecto;
    private float CantidadPuntos;
    private points Puntaje;
    public AudioClip coinClip;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            other.gameObject.GetComponent<points>().agarrar(); // la moneda sumara puntos y se destruir al entrar en contacto con Puntuacion
            Destroy(gameObject);
            AudioManager.instance.PlayAudio(coinClip, "coinSound", false, 0.5f); //la moneda sonara
        }

    }
}

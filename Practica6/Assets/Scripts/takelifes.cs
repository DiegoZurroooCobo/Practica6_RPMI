using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takelifes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //bool lifeRecuperated = GameManager.instance.ReturnLifes();
        //if(lifeRecuperated)
        //{
        //    Destroy(this.gameObject);
        //}
       
        
            if (other.GetComponent<PlayerMovement>())
            {
                GameManager.instance.ReturnLifes(); // la moneda sumara puntos y se destruir al entrar en contacto con Puntuacion
                Destroy(gameObject);
                //audiomanager.instance.PlayAudio(coinClip, "coinSound"); //la moneda sonara
            }

        

    }
}

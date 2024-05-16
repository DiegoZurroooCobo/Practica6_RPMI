using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class InterfaceBoss : MonoBehaviour
{

    
    public Slider sliderPlayer, sliderEnemigo;
    public Button attackButton, healButton, magicButton;

    public void vidaCharacter(Character character)
    {
        sliderPlayer.maxValue = character.GetMaxHealth();
        sliderPlayer.value = character.health;

    }
    public void vidaEnemy(Character enemy)
    {
        sliderEnemigo.maxValue = enemy.GetMaxHealth();
        sliderEnemigo.value = enemy.health;
    }
}

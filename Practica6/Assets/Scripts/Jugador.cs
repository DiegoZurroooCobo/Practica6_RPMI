using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : Character
{
    public Jugador() : base("Player", 30 , Resources.Load<Sprite>("Sprites/cowboy"), 180, 100)
    {
    }

    public override float Attack()
    {
        if (health>30) 
        {
            return damage;
        }
        else
        {
            return damage * 2;
        }
    }

    public override float Magic()
    {
        float currentMana;
        currentMana = 25;
        mana -= currentMana;

        if (mana >= 25)
        {
            if (health > 30)
        {
                return damage * 2;
            }
            else
            {
                return damage * 3;
            }
        }
        else
        {
            return damage;
        }
    }

}

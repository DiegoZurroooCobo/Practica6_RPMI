using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe2 : Character
{
   

    public Jefe2() : base("Yanes", 65 , Resources.Load<Sprite>("Sprites/cowboy") , 600 , 1)
    {
    }

    public override float Heal()
    {
        health += 10;
        base.Heal();
        return 10;
    }
    public override float Attack()
    {
        int kill = Random.Range(0, 1);
        if (kill == 0)
        {
            return damage;
        }
        else
        {
            return 0;
        }
    }

    public override float Magic()
    {
        float cure;
        float currentMana = 1;
        if (mana >= 1) 
        {
            mana -= currentMana;
            cure = GetMaxHealth();
            health += cure;
            base.Heal();
            return cure;
        }
        else
        {
            return 0;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe1 : Character
{
    public Jefe1(): base("Federico", 20 , Resources.Load<Sprite>("Sprites/cowboy"), 250,75)
    {

    }

    public override float Heal()
    {
        float cure;
        cure = damage * 2;
        health += cure;
        base.Heal();
        return cure;
    }
    public override float Attack()
    {
        return damage;
    }

    public override float Magic()
    {
        float currentMana;
        currentMana = 15;
        mana -= currentMana;

        if (mana >= 15) {
            return damage*2;
        }
        else
        {
            return damage;
        }
        
    }

}

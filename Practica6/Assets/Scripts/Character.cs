using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public abstract class Character
{
    private float maxHealth;
    public float health;
    private string _name;
    private Sprite _sprite;
    protected float damage, mana;


    public Character() { }
    public Character(string name, float damage, Sprite sprite, float maxHealth, float mana) // para que todos los hijos del character tengan nombre danyo y un sprite 
    {
        this._name = name;
        this.damage = damage;
        _sprite = sprite;
        this.maxHealth = maxHealth;
        this.mana = mana;
        health = maxHealth;
    }


    public Sprite GetSprite() // el metodo que aparecera en los hijos para los sprites  
    {
        return _sprite;
    }
    public float GetMana() 
    {
        return mana;
    }
    public float GetDamage()  // el metodo que aparecera en los hijos para el da�o 
    {
        return damage;
    }

    public string GetName() // el metodo que aparecera en los hijos para el nombre 

    {
        return _name;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    
    public virtual float Heal() //el metodo que aparecera en los hijos para la vida 
    {
        Debug.Log("Character se cura");
        health = Mathf.Clamp(health, 0, maxHealth);  // lo clampeamos para que al curarse no sobrepase los 100 de vida 
        return health;
    }
    public abstract float Attack(); // un metodo abstracto que no esta definido en la clase padre y que fuerzas a la clase hija 

    public abstract float Magic();
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CombatController : MonoBehaviour
{
    public Character character, enemy;
    private InterfaceBoss interfaceComponent;

    private SpriteRenderer _spriteRenderer;
    public Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        character = new Jugador();
        if (Random.Range(0, 2) == 0)
        {
            enemy = new Jefe1();
        }
        else
        {
            enemy = new Jefe2();
        }
        interfaceComponent = FindObjectOfType<InterfaceBoss>(); // para buscar el objeto de la interfaz
                                                                //     interfaceComponent.vidaEnemy(enemy); // para enseñar la vida del enemigo
    }

    // Update is called once per frame
    void Update()
    {
        interfaceComponent.vidaCharacter(character); // enseñar vida del personaje
        interfaceComponent.vidaEnemy(enemy);
        // ponemos el cooldown en un maximo de 5 
    }
    public void PlayerAttack()
    {
        float dmg = character.Attack(); // para llamar al daño del personaje desde el game manager y guardarlo
        enemy.health -= dmg; // para que el enemigo sufra daño 
        interfaceComponent.vidaEnemy(enemy); // para enseñar la vida del enemigo

        _animator.SetBool("isPunching", true);
       // _animator.Play("Punch");

        StartCoroutine(EnemyAttack());
        
        
    }

    public void PlayerHeal()
    {
        character.Heal(); // llamamos a la vida del personaje desde el gamemanager y la guardamos
        interfaceComponent.vidaCharacter(character); // para enseñar la vida del personaje
        _animator.SetBool("isHealing", true);

        StartCoroutine(EnemyAttack());
    }


    public void PlayerMagic()
    {
        float dmg = character.Magic();
        enemy.health -= dmg; // para que el enemigo sufra daño 
        interfaceComponent.vidaEnemy(enemy);

        _animator.SetBool("isSwording", true);
        StartCoroutine(EnemyAttack());

    }

    public IEnumerator EnemyAttack()
    {
        interfaceComponent.healButton.interactable = false;
        interfaceComponent.magicButton.interactable = false;
        interfaceComponent.attackButton.interactable = false;
        if (enemy.health <= 0)
        {
            _animator.SetBool("isDead", true);
            GameManager.instance.LoadScene("Win");
        }

        if (character.health <= 0)
        {
            _animator.SetBool("isDied", true);
            SceneManager.LoadScene("Menu");
        }
        yield return new WaitForSeconds(4);

        _animator.SetBool("isPunching", false); //FALSEEEEEEEEEEEE
        _animator.SetBool("isHealing", false);
        _animator.SetBool("isSwording", false);

        int num = Random.Range(0, 3); // para coger un valor random de si ataca o no 
        if (num == 0) // si sale 0 el enemigo ataca 
        {
            _animator.SetBool("isAttacking", true);
            float dmg = enemy.Attack(); // para llamar al daño del enemigo 
            character.health -= dmg; // para que al atacar el enemigo haga daño 
            interfaceComponent.vidaEnemy(enemy); // para enseñar la vida del enemigo 

        }
        else if (num == 1) // si sale 1 el enemigo se cura 
        {
            _animator.SetBool("isHealing1", true);
            enemy.Heal();
            interfaceComponent.vidaEnemy(enemy);
        }
        else
        {
            _animator.SetBool("isMana", true);
            if (enemy.GetMana() > 5)
            {
                enemy.Magic();
                interfaceComponent.vidaEnemy(enemy);
            }
            else
            {
                float dmg = enemy.Magic(); // para llamar al daño del enemigo 
                character.health -= dmg; // para que al atacar el enemigo haga daño 
                interfaceComponent.vidaEnemy(enemy);
            }
        }
        _animator.SetBool("isAttackin", false); //FALSEEEEEEEEEEEE
        _animator.SetBool("isHealing1", false);
        _animator.SetBool("isMana", false);

        interfaceComponent.attackButton.interactable = true;
        interfaceComponent.magicButton.interactable = true;
        interfaceComponent.healButton.interactable = true;

        
    }
}


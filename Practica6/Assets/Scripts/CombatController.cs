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
    public Animator _animator, _ani;
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

        CancelAnimation();
        StartCoroutine(EnemyAttack());
        
        
    }

    public void PlayerHeal()
    {
        character.Heal(); // llamamos a la vida del personaje desde el gamemanager y la guardamos
        interfaceComponent.vidaCharacter(character); // para enseñar la vida del personaje
        _animator.SetBool("isHealing", true);

        CancelAnimation();
        StartCoroutine(EnemyAttack());
    }


    public void PlayerMagic()
    {
        float dmg = character.Magic();
        enemy.health -= dmg; // para que el enemigo sufra daño 
        interfaceComponent.vidaEnemy(enemy);

        _animator.SetBool("isSwording", true);
        CancelAnimation();
        StartCoroutine(EnemyAttack());

    }

    public IEnumerator EnemyAttack()
    {
        interfaceComponent.healButton.interactable = false;
        interfaceComponent.magicButton.interactable = false;
        interfaceComponent.attackButton.interactable = false;

        if (enemy.health <= 0)
        {
            _ani.SetBool("isDead", true);
            GameManager.instance.LoadScene("Win");
        }

        yield return new WaitForSeconds(4);

        _animator.SetBool("isPunching", false); //FALSEEEEEEEEEEEE
        _animator.SetBool("isHealing", false);
        _animator.SetBool("isSwording", false);

        int num = Random.Range(0, 3); // para coger un valor random de si ataca o no 
        if (num == 0) // si sale 0 el enemigo ataca 
        {
            float dmg = enemy.Attack(); // para llamar al daño del enemigo 
            character.health -= dmg; // para que al atacar el enemigo haga daño 
            interfaceComponent.vidaEnemy(enemy); // para enseñar la vida del enemigo 
            _ani.SetBool("isAttacking", true);

        }
        else if (num == 1) // si sale 1 el enemigo se cura 
        {
            enemy.Heal();
            interfaceComponent.vidaEnemy(enemy);
            _ani.SetBool("isHealing1", true);
        }
        else
        {
            _ani.SetBool("isMana", true);
            if (enemy.mana < 5)
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

        if (character.health <= 0)
        {
            _animator.SetBool("isDied", true);
            GameManager.instance.LoadScene("Defeat");
        }

        interfaceComponent.attackButton.interactable = true;
        interfaceComponent.magicButton.interactable = true;
        interfaceComponent.healButton.interactable = true;
    }
    public void CancelAnimation() 
    {
        _ani.SetBool("isAttacking", false); //FALSEEEEEEEEEEEE
        _ani.SetBool("isHealing1", false);
        _ani.SetBool("isMana", false);
    }
}


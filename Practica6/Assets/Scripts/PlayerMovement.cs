using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public KeyCode rightKey, leftKey, jumpKey, clikAttack;
    public float speed, jumpForce, rayDistance, bounceSpeed;
    public LayerMask groundMask;// mascara de colisiones que queremos
    public Vector2 pos;
    public AudioClip JumpClip, WalkClip, SwordClip;
    public int maxJump = 2;
    public GameObject sword;

    private SpriteRenderer _rend;
    private Animator _animator;
    private Rigidbody2D rb;
    private Vector2 dir;
    private bool isJumping = false;

    private int doubleJump = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _rend = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
        dir = Vector2.zero;
        if (Input.GetKey(rightKey))
        {
            _rend.flipX = false;
            dir = Vector2.right;
            //AudioManager.instance.PlayAudio(WalkClip, "walksound", false);
        }
        else if (Input.GetKey(leftKey))
        {
            _rend.flipX = true;
            dir = new Vector2(-1, 0);
            //AudioManager.instance.PlayAudio(WalkClip, "walksound", false);
        }

        if (Input.GetKeyDown(clikAttack))
        {   
            {       
                _animator.Play("AttackingIdle");
            }

        }




        if (Input.GetKeyDown(jumpKey))
        {
            isJumping = true;
        }


        #region Animaciones
        if (dir != Vector2.zero)
        {
            _animator.SetBool("IsWalking", true);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }
        #endregion
    }

    public void Bounce() //Salto de Mario Bros con el enemigo
    {
        rb.velocity = new Vector2(rb.velocity.x, bounceSpeed);
    }

    public void DamageZone()
    {
        if (_rend.flipX == false)
        {
            GameObject Attack1 = Instantiate(sword, new Vector2(transform.position.x + 0.45f, transform.position.y), Quaternion.identity);
            AudioManager.instance.PlayAudio(SwordClip, "swordclip", false, 1);
        }
        else
        {
            GameObject Attack1 = Instantiate(sword, new Vector2(transform.position.x - 0.45f, transform.position.y), Quaternion.identity);
            AudioManager.instance.PlayAudio(SwordClip, "swordclip", false, 1);
        }
    }

    private void FixedUpdate()
    {
        bool grnd = IsGrounded();
        // if (dir != Vector2.zero)
        {
            float currentYvel = rb.velocity.y;
            Vector2 nVel = dir * speed;
            nVel.y = currentYvel;
            rb.velocity = nVel;

        }

        if (isJumping && (grnd || doubleJump < maxJump - 1))
        {
            _animator.Play("Jumping");
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce * rb.gravityScale, ForceMode2D.Impulse);
            doubleJump++;
            AudioManager.instance.PlayAudio(JumpClip, "jumpSound", false);
            Debug.Log(doubleJump);
        }

        isJumping = false;


        if (grnd)
        {
            _animator.SetBool("isJumping", false);
        }
        else
        {
            _animator.SetBool("isJumping", true);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHits = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundMask);
        if (raycastHits)
        {
            doubleJump = 0;
            return true;
        }


        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.GetComponent<ResetLevel>())
    //     {
    //         transform.position = pos;
    //     }
    // }

}
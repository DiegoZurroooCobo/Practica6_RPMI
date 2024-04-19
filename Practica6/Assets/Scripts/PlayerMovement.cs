using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public KeyCode rightKey, leftKey, jumpKey, clikAttack;
    public float speed, jumpForce, rayDistance;
    public LayerMask groundMask;// mascara de colisiones que queremos
    public Vector2 pos;
    public AudioClip audioClip;
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
            _rend.flipX = true;
            dir = Vector2.right;
        }
        else if (Input.GetKey(leftKey))
        {
            _rend.flipX = false;
            dir = new Vector2(-1, 0);
        }

        if (Input.GetKeyDown(clikAttack)) 
        {
            if (_rend.flipX == true)
            {
                GameObject Attack1 = Instantiate(sword, new Vector2(transform.position.x+1, transform.position.y), Quaternion.identity);
            }
            else 
            {
                GameObject Attack1 = Instantiate(sword, new Vector2(transform.position.x-1, transform.position.y), Quaternion.identity);
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
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce * rb.gravityScale, ForceMode2D.Impulse);
            doubleJump++;
            //     AudioManager.instance.PlayAudio(audioClip, "jumpSound", false);
            Debug.Log(doubleJump);
        }

        isJumping = false;

      //  if (grnd)
      //  {
      //      _animator.SetBool("IsJumping", false);
      //  }
      //  else
      //  {
      //      _animator.SetBool("IsJumping", true);
      //  }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Tutorial>() != null) 
        { 
            
        }
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
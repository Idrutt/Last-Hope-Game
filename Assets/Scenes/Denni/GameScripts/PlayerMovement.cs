using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;

    private bool doubleJump;

    bool HasdoubleJump = false;

    private Collider2D plCollider;
    private GameObject enColliderr;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    //[SerializeField] private Animator animator;


    private void Start()
    {
        enColliderr = GameObject.FindWithTag("Enemy");
    }
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
           doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                if (HasdoubleJump == true)
                {
                    doubleJump = !doubleJump;
                }
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();

        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

        //animator.SetFloat("Speed", Mathf.Abs(horizontal));
    }
    

    public void ActivateDoubleJump()
    {

        HasdoubleJump = true;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {      
      // Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), enColliderr.GetComponent<CapsuleCollider2D>());
        Physics2D.IgnoreLayerCollision(1, 7, true);
    }

}


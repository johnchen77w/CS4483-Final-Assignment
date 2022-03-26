using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D box2d;
    private Animator anim;

    [SerializeField]private LayerMask jumpableGround;

    private float xDir;
    private SpriteRenderer spr;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 15f;

    private enum MovementState {idle, running, jumping, falling}

    [SerializeField] private AudioSource jumpSFX;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box2d = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        xDir = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xDir * moveSpeed, rb.velocity.y );

        if (Input.GetButtonDown("Jump") && CheckGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSFX.Play();
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;

        if (xDir > 0f)
        {
            state = MovementState.running;
            spr.flipX = false;
        } 
        else if (xDir < 0f)
        {
            state = MovementState.running;
            spr.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("State", (int)state);
    }

    private bool CheckGrounded()
    {
        // Create a lil box same size to the collider
        return Physics2D.BoxCast(box2d.bounds.center, box2d.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}

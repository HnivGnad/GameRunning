using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jump = 12f;
        
    private BoxCollider2D box;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;

    public LayerMask groundLayer;

    private float horizontalInput;
    private bool isJumping;

    [SerializeField] private AudioSource audioJump;

    private enum StateMovement { idle, run, jump, fall }
    StateMovement state = StateMovement.idle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded()) {
            Jump();
        }

        UpdateAnimation();
    }
    private void Jump() {
        rb.velocity = new Vector2(rb.velocity.x, jump);
        audioJump.Play();
    }
    private bool isGrounded() {
        RaycastHit2D raycastHit = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private void UpdateAnimation() {
       
        
        if(horizontalInput > 0) {
            sprite.flipX = false;
            state = StateMovement.run;
        }
        else if(horizontalInput < 0) {
            sprite.flipX = true;
            state = StateMovement.run;
        }
        else {
            state = StateMovement.idle;
        }

        if(rb.velocity.y > 0.1f) {
            state = StateMovement.jump;
        }
        else if(rb.velocity.y < -0.1f) {
            state = StateMovement.fall;
        }
        animator.SetInteger("state", (int)state);
    }
}

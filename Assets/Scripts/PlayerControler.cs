using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed = 2.5f; 
    public float jumpForce = 4f;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    //References
    private Animator _animator;
    private Rigidbody2D _rigidbody;


    //Move the player
    private bool _facingRight = true;
    private Vector2 _movement;
    private bool _isGrounded;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); //GetAxisRaw just give you from 0 to 1
        _movement = new Vector2(horizontalInput, 0f);
        if(horizontalInput < 0f && _facingRight)
        {
            Flip();
        } else if (horizontalInput > 0 && !_facingRight) { Flip(); }

        //is grounded?
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius, groundLayer);
        Debug.Log("is Grounded: " + _isGrounded);
        //is jumping??
        if(Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }

    private void FixedUpdate()
    {
        float horizontalVelocity = _movement.normalized.x * speed;
        _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);

        
    }

    private void LateUpdate()
    {
        _animator.SetBool("isMoving", _movement != Vector2.zero);
        _animator.SetBool("isGrounded", _isGrounded);
        _animator.SetFloat("JumpVelocity", _rigidbody.velocity.y);
    }

    //Flip player to the left or right.
    void Flip()
    {
        _facingRight = !_facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
    }
}

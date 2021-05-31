using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Speed of player")]
    [SerializeField] private float moveForce = 10.0f;
    [Tooltip("Force against gravity to jump")]
    [SerializeField] private float jumpForce = 11.0f;

    [Tooltip("Max Speed of player")] [SerializeField]
    private float maxSpeed = 22.0f;
        
    private Rigidbody2D _playerRb2D;
    private Animator _playerAnimator;
    private SpriteRenderer _playerSpriteRenderer;
    
    private bool _isJumping;
    private bool _isWalking;
    private float _movementX; 
    
    private string Horizontal = "Horizontal";
    private string IsJumping = "IsJumping";
    private string IsWalking = "IsWalking";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";
    private void Awake()
    {
        _playerRb2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PlayerMovement();
        AnimationPlayer();
        Jump();
    }   

    private void PlayerMovement()
    {
        _movementX = Input.GetAxisRaw(Horizontal);
        if (Math.Abs(_movementX) >= 0.5)
        {
            _isWalking = true;
            transform.position += new Vector3(_movementX, 0,0) * (Time.deltaTime * moveForce);
        }
        else
        {
            _isWalking = false;
        }

    }

    private void Jump()
    {
        _playerAnimator.SetBool(IsJumping, _isJumping);
        if (Input.GetButtonDown("Jump") && !_isJumping)
        {
            _isJumping = true;
            _playerRb2D.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);
            
        }
       
    }

    private void AnimationPlayer()
    {

        _playerAnimator.SetBool(IsWalking, _isWalking);
        if (_movementX == 0) return;
        _playerSpriteRenderer.flipX = _movementX < 0 ? true : false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(GROUND_TAG))
        {
            _isJumping = false;
        }

        if (other.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}

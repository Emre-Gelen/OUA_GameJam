using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float MovementSpeed = 7f;
    public float JumpForce = 13f;
    public float GroundCheckRadius;
    public float WallCheckDistance;
    public float WallSlidingSpeed;
    public float MovementForceInAir;
    public float AirDragMultiplier = 0.95f;
    public float VariableJumpMultiplier = 0.5f;
    public float WallHopForce = 10f;
    public float WallJumpForce = 10f;

    public int MaxJumpCount = 2;

    public Vector2 WallHopDirection;
    public Vector2 WallJumpDirection;

    private float _movementDirection;

    private int _restOfJumps;
    private int _facingDirection = 1;

    private bool _isFacingRight = true;
    private bool _isGrounded;
    private bool _canJump;
    private bool _isTouchingWall;
    private bool _isWallSliding;

    private Rigidbody2D _characterRB;
    private Animator _characterAnimator;

    public Transform GroundCheck;
    public Transform WallCheck;
    public LayerMask GroundLayer;


    // Aydin - Dash degiskenleri
    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer _trailRenderer;

    void Start()
    {
        _characterRB = GetComponent<Rigidbody2D>();
        _characterAnimator = GetComponent<Animator>();

        WallJumpDirection.Normalize();
        WallHopDirection.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        // Anlik dash atma kontrolu
        if (isDashing) {
            return;
        }

        CheckDirection();
        CheckJump();
        UpdateAnimations();
        CheckIfCanJump();
        CheckIfWallSliding();

        // Dash Baslatma Kontrolu
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash) {

            StartCoroutine(Dash());
        }

    }

    void FixedUpdate()
    {

        //Anlik dash atma kontolu
        if (isDashing) {
            return;
        }
        ApplyMovement();
        CheckSurroundings();
    }

    void CheckIfWallSliding()
    {
        _isWallSliding = !_isGrounded && _isTouchingWall && _characterRB.velocity.y < 0;
    }

    void CheckSurroundings()
    {
        _isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundLayer);
        _isTouchingWall = Physics2D.Raycast(WallCheck.position, transform.right, WallCheckDistance, GroundLayer);
    }

    void CheckDirection()
    {
        _movementDirection = Input.GetAxisRaw("Horizontal");

        if ((_isFacingRight && _movementDirection < 0) || !_isFacingRight && _movementDirection > 0)
        {
            Flip();
        }
    }

    void CheckIfCanJump()
    {
        if ((_isGrounded && _characterRB.velocity.y <= 0.01f) || _isWallSliding)
        {
            _restOfJumps = MaxJumpCount;
        }
        _canJump = _restOfJumps > 0;
    }
    void CheckJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonUp("Jump"))
        {
            _characterRB.velocity = new Vector2(_characterRB.velocity.x, _characterRB.velocity.y * VariableJumpMultiplier);
        }
    }

    void UpdateAnimations()
    {
        _characterAnimator.SetBool("IsWalking", _characterRB.velocity.x != 0);
        _characterAnimator.SetBool("IsGrounded", _isGrounded);
        _characterAnimator.SetFloat("yVelocity", _characterRB.velocity.y);
        _characterAnimator.SetBool("IsWallSliding", _isWallSliding);
    }

    void Jump()
    {
        if (_canJump)
        {
            if (!_isWallSliding)
            {
                _characterRB.velocity = new Vector2(_characterRB.velocity.x, JumpForce);
            }
            else if (_isWallSliding && _movementDirection == 0)
            {
                _characterRB.AddForce(new Vector2(WallHopForce * WallHopDirection.x * -_facingDirection, WallHopForce * WallHopDirection.y), ForceMode2D.Impulse);
            }
            else if ((_isWallSliding || _isTouchingWall) && _movementDirection != 0)
            {
                _characterRB.AddForce(new Vector2(WallJumpForce * WallJumpDirection.x * _movementDirection, WallJumpForce * WallJumpDirection.y), ForceMode2D.Impulse);
            }
            _restOfJumps--;
        }
    }

    void ApplyMovement()
    {
        if (_isGrounded)
        {
            _characterRB.velocity = new Vector2(_movementDirection * MovementSpeed, _characterRB.velocity.y);
        }
        else if (!_isGrounded && !_isWallSliding)
        {
            if (_movementDirection != 0)
            {
                _characterRB.AddForce(new Vector2(MovementForceInAir * _movementDirection, 0));
                if (Math.Abs(_characterRB.velocity.x) > MovementSpeed)
                {
                    _characterRB.velocity = new Vector2(MovementSpeed * _movementDirection, _characterRB.velocity.y);
                }
            }
            else
            {
                _characterRB.velocity = new Vector2(_characterRB.velocity.x * AirDragMultiplier, _characterRB.velocity.y);
            }
        }

        if (_isWallSliding && _characterRB.velocity.y < -WallSlidingSpeed)
        {
            _characterRB.velocity = new Vector2(_characterRB.velocity.x, -WallSlidingSpeed);
        }
    }

    void Flip()
    {
        if (!_isWallSliding)
        {
            _facingDirection *= -1;
            _isFacingRight = !_isFacingRight;
            this.transform.Rotate(0f, 180f, 0f);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(GroundCheck.position, GroundCheckRadius);

        Gizmos.DrawLine(WallCheck.position, new Vector3(WallCheck.position.x + WallCheckDistance, WallCheck.position.y, WallCheck.position.z));
    }

    // Dash icin core routine
    private IEnumerator Dash() {

        canDash = false;
        isDashing = true;

        float originalGravity = _characterRB.gravityScale;
        _characterRB.gravityScale = 0f;

        if (_isFacingRight)
        {
            _characterRB.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        }
        else {
            _characterRB.velocity = new Vector2(transform.localScale.x * -dashingPower, 0f);

        }

        _trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        _trailRenderer.emitting = false;
        _characterRB.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
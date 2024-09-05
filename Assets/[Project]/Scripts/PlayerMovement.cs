using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] bool ENABLE_DEBUG = true;
    [Space]
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _jumpForce = 5;
    [SerializeField] private float _gravityScale = 1;
    [SerializeField] private float _groundSlamForce = 1;
    [Header("Ground Check :")]
    [SerializeField] private float _checkDistance;
    [SerializeField] private float _checkRaduis;
    [SerializeField] private LayerMask _checkMask;
    private float _currentfallingSpeed;
    private InputAction _jumpAction;
    private bool _hasJump = false;
    private bool _canJump = false;
    private bool _canSlam = false;
    private Vector2 _currentVelocity;
    private Rigidbody2D _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _jumpAction = GetComponent<PlayerInput>().actions.FindAction("Jump");
    }

    private void FixedUpdate()
    {
        // _hasJump = _jumpAction.ReadValue<float>() > .5f;
        ComputeVelocity();
    }

    private void OnJump(InputValue value)
    {
        _hasJump = value.Get<float>() > .5f;
    }

    private void ComputeVelocity()
    {

        // _currentVelocity.x = Mathf.Lerp(_currentVelocity.x, _moveSpeed, Time.deltaTime);
        _currentVelocity.x = _moveSpeed;
        _currentVelocity.y = IsGrounded() ? -.5f : Mathf.Lerp(_currentVelocity.y, Physics2D.gravity.y * _gravityScale, Time.deltaTime);

        if (IsGrounded() && _hasJump && _canJump)
        {
            print("Jump");
            _canJump = false;
            _hasJump = false;
            _currentVelocity.y = _jumpForce;
        }

        if(!IsGrounded() && _hasJump && _canSlam)
        {
            print("Slam");
            _canSlam = false;
            _hasJump = false;
            _currentVelocity.y = _groundSlamForce;
        }

        _rb.velocity = _currentVelocity;
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position
                                                , _checkRaduis
                                                , -transform.up
                                                , _checkDistance
                                                , _checkMask);
        if (_currentVelocity.y < 0 && hit)
        {
            _canJump = true;
            _canSlam = true;
        }

        return hit;
    }

    private void OnDrawGizmos()
    {
        if(!ENABLE_DEBUG) return;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -transform.up * _checkDistance);
        Gizmos.DrawSphere(transform.TransformPoint(-transform.up * _checkDistance), _checkRaduis);
    }
}

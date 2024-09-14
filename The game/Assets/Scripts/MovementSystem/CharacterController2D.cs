using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{

    [SerializeField] private float _speed = 5f;
    private Vector2 _movementDirection;
    private Animator _animator;
    private Rigidbody2D _rb;
    private bool isMoving;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _movementDirection.Normalize();
        isMoving = _movementDirection != Vector2.zero;


        if (isMoving)
        {
            HandleRotation(_movementDirection);
        }

        _animator.SetBool("isMoving", isMoving);
    }

    private void FixedUpdate()
    {
        _rb.velocity = _movementDirection * _speed;
    }

    private void HandleRotation(Vector2 direction)
    {

        if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


        if (direction.y > 0 || direction.y < 0)
        {
            // Если движение только вверх/вниз, оставляем текущее направление по оси X
        }
    }
}

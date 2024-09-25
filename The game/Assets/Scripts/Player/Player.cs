using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb; 
    private MovementSystem _movementSystem;
    private Vector2 _inputVector;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _movementSystem = GetComponent<MovementSystem>();
    }

    private void Start()
    {
        _movementSystem.Speed = 7.0f;
    }

    private void Update()
    {
        _inputVector= GameInput.Instance.Get_inputVector();
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movementSystem.ProcessingInputVector(_inputVector));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    private bool _isLookingRight;
    [SerializeField] private float _speed;

    public bool IsLookingRight
    {
        get { return _isLookingRight; }
        set { }
    }

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public Vector2 ProcessingInputVector(Vector2 inputVector)
    {
        if (inputVector.x > 0) { _isLookingRight = true; }
        if (inputVector.x < 0) { _isLookingRight = false; }
        return inputVector.normalized * (_speed * Time.fixedDeltaTime);
    }

    public static Vector3 GetRandomDir()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}

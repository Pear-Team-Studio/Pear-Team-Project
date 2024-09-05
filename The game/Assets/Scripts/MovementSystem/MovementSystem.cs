using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    private bool _isLookingRight;
    private float _speed;

    public bool IsLookingRight 
    { 
        get { return _isLookingRight;}
        set { } 
    }


    public MovementSystem(float speed)
    {
        _speed = speed;
        _isLookingRight = true;
    }

    public Vector2 ProcessingInputVector(Vector2 inputVector)
    { 
        if(inputVector.x>0) { _isLookingRight = true; }
        if(inputVector.x<0) { _isLookingRight = false; }
        return inputVector.normalized * (_speed * Time.fixedDeltaTime);
    }
}

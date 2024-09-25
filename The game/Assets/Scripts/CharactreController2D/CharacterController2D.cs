using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    private Animator _animator;
    private MovementSystem _movementSystem;
    private const string IS_MOVING= "isMoving";

    void Start()
    {
        _animator = GetComponent<Animator>();
        _movementSystem = transform.parent.GetComponent<MovementSystem>();
    }

    void Update()
    {
        _animator.SetBool(IS_MOVING, _movementSystem.IsMoving);
    }

    private void FixedUpdate()
    {
        if (!_movementSystem.IsLookingRight)
        {
            /*В дальнейшем (когда будет добавлен спрайт и спрайт рендер) здесь будет флипаться спрайт*/
        }
    }

}

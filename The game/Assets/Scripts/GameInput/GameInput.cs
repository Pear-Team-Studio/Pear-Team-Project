using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;
    public static GameInput Instance;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Enable();
        Instance = this;
    }

    public Vector2 Get_inputVector()
    {
        return _playerInputActions.Player.Movement.ReadValue<Vector2>();
    }
}

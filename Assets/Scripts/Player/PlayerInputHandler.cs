using System;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour, IInput
{
    private Vector3 _frameVelocity;

    public event Action OnAttack;

    private void Awake()
    {
        _frameVelocity = new Vector3 (0, 0, 0);
    }

    public void OnAttackButtonClick()
    {
        OnAttack?.Invoke();
    }

    public Vector3 GetFrameVelocity()
    {
        return _frameVelocity;
    }

    public void OnRightButtonDown()
    {
        _frameVelocity.x = 1;
    }

    public void OnRightButtonUp() 
    {
        _frameVelocity.x = 0;
    }

    public void OnLeftButtonDown()
    {
        _frameVelocity.x = -1;
    }

    public void OnLeftButtonUp()
    {
        _frameVelocity.x = 0;
    }
    public void OnUpButtonDown()
    {
        _frameVelocity.z = 1;
    }

    public void OnUpButtonUp()
    {
        _frameVelocity.z = 0;
    }
    public void OnDownButtonDown()
    {
        _frameVelocity.z = -1;
    }
    public void OnDownButtonUp()
    {
        _frameVelocity.z = 0;
    }
}

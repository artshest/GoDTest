using System;
using UnityEngine;

public interface IInput
{
    public event Action OnAttack;

    public Vector3 GetFrameVelocity();
}

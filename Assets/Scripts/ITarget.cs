
using UnityEngine;

public interface ITarget : IService
{
    public IDamageable GetTarget();

    public Vector3 GetTargetPosition();
}

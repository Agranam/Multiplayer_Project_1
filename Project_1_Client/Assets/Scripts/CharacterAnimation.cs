using System;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private CheckFly _checkFly;
    [SerializeField] private Animator _animator;
    [SerializeField] private Character _character;
    
    private readonly int _grounded = Animator.StringToHash("Grounded");
    private readonly int _speed = Animator.StringToHash("Speed");

    private void Update()
    {
        Vector3 localVelocity = _character.transform.InverseTransformVector(_character.Velocity);
        float speed = localVelocity.magnitude / _character.Speed;
        float sign = MathF.Sign(localVelocity.z);
        
        _animator.SetFloat(_speed, speed * sign);
        _animator.SetBool(_grounded, !_checkFly.IsFly);
    }
}

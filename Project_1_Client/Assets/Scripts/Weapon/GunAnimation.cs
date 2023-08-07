using System;
using UnityEngine;

public class GunAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Gun _gun;
    
    private readonly int _shoot = Animator.StringToHash("Shoot");

    private void Start()
    {
        _gun.OnShoot += Shoot;
    }

    private void Shoot()
    {
        _animator.SetTrigger(_shoot);
    }

    private void OnDestroy()
    {
        _gun.OnShoot -= Shoot;
    }
}

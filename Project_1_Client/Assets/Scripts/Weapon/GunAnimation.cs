using System;
using UnityEngine;

public class GunAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerGun _playerGun;
    
    private readonly int _shoot = Animator.StringToHash("Shoot");

    private void Start()
    {
        _playerGun.OnShoot += Shoot;
    }

    private void Shoot()
    {
        _animator.SetTrigger(_shoot);
    }

    private void OnDestroy()
    {
        _playerGun.OnShoot -= Shoot;
    }
}

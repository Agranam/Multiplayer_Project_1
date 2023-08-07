using System;
using UnityEngine;

public class PlayerGun : Gun
{
    [SerializeField] private Transform _bulletSpawner;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _shootDelay = 0.2f;

    private float _lastShootTime;

    
    public bool TryShoot(out ShootInfo shootInfo)
    {
        shootInfo = new ShootInfo();
        if(Time.time - _lastShootTime < _shootDelay) return false;
        _lastShootTime = Time.time;

        Vector3 position = _bulletSpawner.position;
        Vector3 velocity = _bulletSpawner.forward * _bulletSpeed;
        Debug.Log("Shoot");
        var bullet = Instantiate(_bulletPrefab, position, _bulletSpawner.rotation);
        bullet.Init(velocity);
        OnShoot?.Invoke();

        shootInfo.Init(position, velocity);
        return true;
    }
}

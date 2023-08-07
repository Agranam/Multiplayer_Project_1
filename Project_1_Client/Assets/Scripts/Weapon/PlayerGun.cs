using System;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletSpawner;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _shootDelay = 0.2f;

    private float _lastShootTime;

    public Action OnShoot;
    
    public void Shoot()
    {
        if(Time.time - _lastShootTime < _shootDelay) return;
        _lastShootTime = Time.time;
        
        var bullet = Instantiate(_bulletPrefab, _bulletSpawner.position, _bulletSpawner.rotation);
        bullet.Init(_bulletSpawner.forward, _bulletSpeed);
        OnShoot?.Invoke();
    }
}

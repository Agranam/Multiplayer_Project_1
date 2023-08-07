using UnityEngine;

public class EnemyGun : Gun
{
    public void Shoot(Vector3 position, Vector3 velocity)
    {
        var bullet = Instantiate(_bulletPrefab, position, Quaternion.identity);
        bullet.Init(velocity);
        OnShoot?.Invoke();
    }
}

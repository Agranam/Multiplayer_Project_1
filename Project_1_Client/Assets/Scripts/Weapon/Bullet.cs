using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _lifeTime = 3f;

    private float _lifeTimer;
    
    private void Update()
    {
        _lifeTimer += Time.deltaTime;

        if (_lifeTimer >= _lifeTime) {
            Destroy();
        }
    }

    public void Init(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}

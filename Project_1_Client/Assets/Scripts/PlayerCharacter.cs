using System;
using UnityEngine;

public class PlayerCharacter : Character
{
    [SerializeField] private CheckFly _checkFly;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _cameraPoint;
    [SerializeField] private float _jumpForce = 3;
    [SerializeField] private float _jumpDelay = 0.2f;
    [SerializeField] private float _maxHeadAngle = 80;
    [SerializeField] private float _minHeadAngle = -80;

    private float _inputH;
    private float _inputV;
    private float _rotateY;
    private float _currentRotateX;
    private float _jumpTime;

    private void Start()
    {
        Transform camera = Camera.main.transform;
        camera.parent = _cameraPoint;
        camera.localPosition = Vector3.zero;
        camera.localRotation = Quaternion.identity;
    }

    private void FixedUpdate()
    {
        Move();
        RotateY();
    }

    public void SetInput(float h, float v, float rotateY)
    {
        _inputH = h;
        _inputV = v;
        _rotateY += rotateY;
    }

    private void RotateY()
    {
        _rigidbody.angularVelocity = new Vector3(0, _rotateY, 0);
        _rotateY = 0;
    }
    
    public void RotateX(float angleX)
    {
        _currentRotateX = Mathf.Clamp(_currentRotateX + angleX, _minHeadAngle, _maxHeadAngle);
        _head.localEulerAngles = new Vector3(_currentRotateX, 0, 0);
    }

    private void Move()
    {
        Vector3 velocity = (transform.forward * _inputV + transform.right * _inputH).normalized * Speed;
        velocity.y = _rigidbody.velocity.y;
        Velocity = velocity;
        _rigidbody.velocity = Velocity;
    }

    public void Jump()
    {
        if(_checkFly.IsFly) return;
        if(Time.time - _jumpTime< _jumpDelay) return;

        _jumpTime = Time.time;
        _rigidbody.AddForce(0, _jumpForce, 0, ForceMode.VelocityChange);
    }

    public void GetMoveInfo(out Vector3 position, out Vector3 velocity, out float rotateX, out float rotateY)
    {
        position = transform.position;
        velocity = _rigidbody.velocity;
        
        rotateX = _head.localEulerAngles.x;
        rotateY = transform.eulerAngles.y;
    }
}

using UnityEngine;

public class EnemyCharacter : Character
{
    [SerializeField] private Transform _head;
    private float _velocityMagnitude;
    
    public Vector3 TargetPosition { get; private set; } = Vector3.zero;

    private void Start()
    {
        TargetPosition = transform.position;
    }

    private void Update()
    {
        if(_velocityMagnitude > 0.1f) {
            float maxDistance = _velocityMagnitude * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, maxDistance);
        } else {
            transform.position = TargetPosition;
        }
    }

    public void SetSpeed(float speed) => Speed = speed;

    public void SetRotateX(float angleX)
    {
        _head.localEulerAngles = new Vector3(angleX, 0, 0);
    }
    public void SetRotateY(float angleY)
    {
        transform.localEulerAngles = new Vector3(0, angleY, 0);
    }
    
    public void SetMovement(in Vector3 position, in Vector3 velocity, float averageInterval)
    {
        TargetPosition = position + (velocity * averageInterval);
        _velocityMagnitude = velocity.magnitude;
        Velocity = velocity;
    }
}

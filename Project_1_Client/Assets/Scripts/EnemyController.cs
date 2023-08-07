using System.Collections.Generic;
using System.Linq;
using Colyseus.Schema;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyCharacter _enemy;
    [SerializeField] private EnemyGun _enemyGun;

    private List<float> _receiveTimeIntervals = new() {0, 0, 0, 0, 0};
    private Player _player;
    private float _lastReceiveTime;

    public void Init(Player player)
    {
        _player = player;
        _enemy.SetSpeed(player.speed);
        player.OnChange += OnChange;
    }

    public void Shoot(in ShootInfo info)
    {
        Vector3 position = new Vector3(info.pX, info.pY, info.pZ);
        Vector3 velocity = new Vector3(info.vX, info.vY, info.vZ);
        
        _enemyGun.Shoot(position, velocity);
    }
    
    private void SaveReceiveTime()
    {
        float interval = Time.time - _lastReceiveTime;
        _lastReceiveTime = Time.time;
        
        _receiveTimeIntervals.Add(interval);
        _receiveTimeIntervals.Remove(0);
    }

    public void Destroy()
    {
        _player.OnChange -= OnChange;
        Destroy(gameObject);
    }
    
    internal void OnChange(List<DataChange> changes)
    {
        SaveReceiveTime();

        Vector3 position = _enemy.TargetPosition;
        Vector3 velocity = _enemy.Velocity;

        foreach (var dataChange in changes) {
            switch (dataChange.Field) {
                case "pX":
                    position.x = (float) dataChange.Value;
                    break;
                case "pY":
                    position.y = (float) dataChange.Value;
                    break;
                case "pZ":
                    position.z = (float) dataChange.Value;
                    break;
                case "vX":
                    velocity.x = (float) dataChange.Value;
                    break;
                case "vY":
                    velocity.z = (float) dataChange.Value;
                    break;
                case "vZ":
                    velocity.z = (float) dataChange.Value;
                    break;
                case "rX":
                    _enemy.SetRotateX((float) dataChange.Value);
                    break;
                case "rY":
                    _enemy.SetRotateY((float) dataChange.Value);
                    break;
                default:
                    Debug.LogWarning($"{dataChange.Field} not handled");
                    break;
            }
        }

        _enemy.SetMovement(position, velocity, _receiveTimeIntervals.Average());
    }
}

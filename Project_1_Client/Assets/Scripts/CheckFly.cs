using System;
using UnityEngine;

public class CheckFly : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _radius = 0.2f;
    [SerializeField] private float _delayTime = 0.15f;

    private float _flyTimer;
    
    public bool IsFly { get; private set; }

    private void Update()
    {
        if (Physics.CheckSphere(transform.position, _radius, _layerMask)) {
            IsFly = false;
            _flyTimer = 0;
        } else {
            _flyTimer += Time.deltaTime;
            
            if(_flyTimer >= _delayTime)
                IsFly = true;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
#endif
}

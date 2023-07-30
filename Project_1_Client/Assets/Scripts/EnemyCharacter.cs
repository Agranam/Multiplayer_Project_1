using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    public void SetInput(Vector3 position)
    {
        transform.position = position;
    }
}

using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class EnemyAttack : MonoBehaviour
{
    private Rotator _rotator;

    private void Awake()
    {
        _rotator = GetComponent<Rotator>();
    }

    public void Attack(Vector2 targetPosition)
    {
        _rotator.Rotate(targetPosition);
    }
}


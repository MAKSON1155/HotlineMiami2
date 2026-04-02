using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class EnemyAttack : MonoBehaviour
{
    private EnemyMover _mover;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
    }

    public void Attack(Vector2 targetPosition)
    {
        _mover.Rotate(targetPosition);

    }
}


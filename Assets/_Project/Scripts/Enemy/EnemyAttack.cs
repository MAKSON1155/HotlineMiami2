using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    private Rotator _rotator;

    private void Awake()
    {     
        _rotator = GetComponent<Rotator>();      
        _weapon = GetComponent<Weapon>();
    }

    public void Attack(Vector2 targetPosition)
    {
        _rotator.Rotate(targetPosition);
        _weapon.Shot();
    }
}


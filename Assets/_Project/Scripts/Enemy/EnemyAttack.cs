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
        _weapon.Refresh(_weapon.Weapons[0]);
    }

    public void Attack(Vector2 targetPosition)
    {
        _rotator.Rotate(targetPosition);
        _weapon.Shot();
    }
}


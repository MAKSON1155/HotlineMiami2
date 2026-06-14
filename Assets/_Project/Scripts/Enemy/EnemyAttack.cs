using UnityEngine;

[RequireComponent(typeof(Rotator))]
public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _attackRange = 10f;
    [SerializeField] private float _shootDelay = 1f;

    private Rotator _rotator;
    private float _lastShootTime;
    private bool _isAttacking = false;
    private Vector2 _targetPosition;

    private void Awake()
    {
        _rotator = GetComponent<Rotator>();
    }

    private void Update()
    {
        if (_isAttacking == false || _weapon == null)
            return;

        if (_targetPosition == Vector2.zero)
            return;

        _rotator.Rotate(_targetPosition);

        float distance = Vector2.Distance(transform.position, _targetPosition);

        if (distance <= _attackRange && Time.time >= _lastShootTime + _shootDelay)
        {
            Shoot();
            _lastShootTime = Time.time;
        }
    }

    public void StartAttack(Vector2 targetPosition)
    {
        if (targetPosition == _targetPosition)
        {
            _targetPosition = Vector2.zero;
            return;
        }

        _targetPosition = targetPosition;
        _isAttacking = true;
    }

    public void StopAttack() => _isAttacking = false;

    private void Shoot()
    {
        Vector2 shootDirection = (_targetPosition - (Vector2)transform.position).normalized;
        _weapon.ShootAtDirection(shootDirection);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}
using System;
using UnityEngine;

[RequireComponent(typeof(EnemyPatrol), typeof(EnemyAttack), typeof(EnemiesDetector))]
public class EnemyBrain : MonoBehaviour, IDamageable
{
    private EnemyPatrol _patrol;
    private EnemyAttack _attack;
    private EnemiesDetector _detector;
    private bool _isChasing = false;
    public event Action HasDamaged;

    private void Awake()
    {
        _patrol = GetComponent<EnemyPatrol>();
        _attack = GetComponent<EnemyAttack>();
        _detector = GetComponent<EnemiesDetector>();
    }

    private void OnEnable()
    {
        _detector.HasDetected += OnPlayerDetected;
    }

    private void OnDisable()
    {
        _detector.HasDetected -= OnPlayerDetected;
        _attack.StopAttack();
    }

    private void OnPlayerDetected(Vector2 playerPosition)
    {
        if (_isChasing == false)
        {
            _patrol.Stop();
            _isChasing = true;
        }

        _attack.StartAttack(playerPosition);
    }

    public void TakeDamage()
    {
        Destroy(gameObject);
        HasDamaged?.Invoke();
    }
}
using UnityEngine;

[RequireComponent(typeof(EnemyPatrol), typeof(EnemyAttack))]
public class EnemySwitcher : MonoBehaviour
{
    private EnemiesDetector _detector;
    private EnemyPatrol _patrol;
    private EnemyAttack _attack;

    private void Awake()
    {
        _detector = GetComponent<EnemiesDetector>();
        _patrol = GetComponent<EnemyPatrol>();
        _attack = GetComponent<EnemyAttack>();
    }
    private void OnEnable()
    {
        _detector.HasDetected += Switch;
    }

    private void OnDisable()
    {
        _detector.HasDetected -= Switch;
    }

    private void Switch(Vector2 targetPosition)
    {
        _patrol.StopPatrol();
        _attack.Attack(targetPosition);
    }
}


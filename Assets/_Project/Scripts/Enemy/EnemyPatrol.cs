using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private PatrolPoint[] _patrolPoints;

    private EnemyMover _mover;
    private Rigidbody2D _rigidbody;
    private WaitForSeconds _waitForSeconds;
    private Coroutine _currentCoroutine;

    private readonly float _stopDistance = 0.1f;
    private readonly float _sleep = 1f;
    private int _currentPoint = 0;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _waitForSeconds = new WaitForSeconds(_sleep);
        _currentCoroutine = null;
    }

    private void Start()
    {
        _currentCoroutine = StartCoroutine(Patrol());
    }

    public void StopPatrol()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = null;
        _mover.Stop();
    }

    private IEnumerator Patrol()
    {
        while (true)
        {
            Vector2 targetPosition = _patrolPoints[_currentPoint].transform.position;
            Vector2 offset = targetPosition - _rigidbody.position;

            if (offset.magnitude < _stopDistance)
            {
                _currentPoint = ++_currentPoint % _patrolPoints.Length;
                _mover.Stop();
                yield return _waitForSeconds;
            }

            _mover.Move(targetPosition);
            yield return null;
        }
    }
}
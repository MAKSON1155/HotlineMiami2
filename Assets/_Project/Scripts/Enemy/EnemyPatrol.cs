using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private PatrolPoint[] _points;
    private WaitForSeconds _waitingTime;
    private EnemyMover _mover;
    private float _thresholdSqr = 0.5f;
    private int _currentIndex = 0;
    private int _sleep = 1;
    private Coroutine _current;

    private void Start()
    {
        _current = StartCoroutine(Patrol());
    }

    private void Awake()
    {   
        _waitingTime = new WaitForSeconds(_sleep);
        _mover = GetComponent<EnemyMover>();
    }

    public void StopPatrol()
    {
        if (_current != null)             
            StopCoroutine(_current);

        _current = null;
        _mover.Stop();
    }

    private IEnumerator Patrol()
    {
        while (true)
        {
            Vector2 targetPosition = _points[_currentIndex].transform.position;
            Vector2 direction = targetPosition - (Vector2)transform.position;

            if (direction.sqrMagnitude <= _thresholdSqr)
            {
                _currentIndex = _currentIndex++ % _points.Length;
                _mover.Stop();
                yield return _waitingTime;
                continue;
            }

            _mover.Move(direction, _thresholdSqr);
            yield return null;
        }
    }
}


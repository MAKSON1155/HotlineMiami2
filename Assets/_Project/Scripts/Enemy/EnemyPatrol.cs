using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(Rotator))]
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private PatrolPoint[] _points;
    [SerializeField] private float _pointReachDistance = 1f;

    private EnemyMover _mover;
    private Rotator _rotator;
    private Transform _targetPoint;
    private int _index;
    private bool _isPatrolling = true;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _rotator = GetComponent<Rotator>();
    }

    private void Update()
    {
        if (_isPatrolling == false)
            return;

        if (_points == null || _points.Length == 0)
            return;

        _targetPoint = _points[_index].transform;
        _rotator.Rotate(_targetPoint.position);
        _mover.MoveTo(_targetPoint.position);

        if (Vector2.Distance(transform.position, _targetPoint.position) < _pointReachDistance)
            _index = (_index + 1) % _points.Length;
    }

    public void Stop()
    {
        _isPatrolling = false;
        _mover.Stop();
    }
}
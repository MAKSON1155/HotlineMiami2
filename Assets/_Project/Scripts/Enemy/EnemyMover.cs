using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _stopDistance = 0.3f;

    private Rigidbody2D _rigidbody;
    private Vector2 _offset;

    public bool IsMoving { get; private set; } = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveTo(Vector2 target)
    {
        _offset = target - _rigidbody.position;

        if (_offset.sqrMagnitude < _stopDistance * _stopDistance)
        {
            _rigidbody.velocity = Vector2.zero;
            return;
        }

        IsMoving = true;
        _rigidbody.velocity = _offset.normalized * _speed;
    }

    public void Stop()
    {
        IsMoving = false;
        _rigidbody.velocity = Vector2.zero;
    }
}
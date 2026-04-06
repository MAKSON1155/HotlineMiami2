using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Rotator))]
public class EnemyMover : MonoBehaviour
{  
    [SerializeField] private float _moveSpeed = 4f;
    [SerializeField] private float _stopDistance = 0.1f;

    private Rigidbody2D _rigidbody;
    private Rotator _rotator;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rotator = GetComponent<Rotator>();
    }

    public void Move(Vector2 targetPosition)
    {
        _rotator.Rotate(targetPosition);

        Vector2 currentPosition = _rigidbody.position;
        Vector2 offset = targetPosition - currentPosition;

        if (offset.magnitude < _stopDistance)
            Stop();

        Vector2 direction = offset.normalized;
        _rigidbody.velocity = direction * _moveSpeed;
    }

    public void Stop()
    {
        _rigidbody.velocity = Vector2.zero;
    }
}
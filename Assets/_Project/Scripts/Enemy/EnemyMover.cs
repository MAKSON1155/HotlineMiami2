using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _stopDistance = 0.3f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveTo(Vector2 target)
    {
        Vector2 offset = target - _rigidbody.position;

        if (offset.sqrMagnitude < _stopDistance * _stopDistance)
        {
            _rigidbody.velocity = Vector2.zero;
            return;
        }

        _rigidbody.velocity = offset.normalized * _speed;
    }

    public void Stop()
    {
        _rigidbody.velocity = Vector2.zero;
    }
}
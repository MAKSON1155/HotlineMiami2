using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 10f;
    private Rigidbody2D _rigidbody;

    public Vector2 Direction { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Rotate(Vector2 targetPosition)
    {
        Vector2 direction = (targetPosition - _rigidbody.position).normalized;

        if (direction == Vector2.zero)
            direction = Vector2.right;

        Direction = direction;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float angularDifference = Mathf.DeltaAngle(_rigidbody.rotation, targetAngle);

        _rigidbody.angularVelocity = angularDifference * _rotationSpeed;
    }
}
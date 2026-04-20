using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    private Rigidbody2D _rigidbody;

    public Vector2 Direction { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Rotate(Vector2 targetPosition)
    {
        Vector2 currentPosition = _rigidbody.position;
        Vector2 direction = (targetPosition - currentPosition).normalized;
        Direction = direction;

        float targetAngel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float currentAngel = _rigidbody.rotation;
        float angularDifference = Mathf.DeltaAngle(currentAngel, targetAngel);

        if (Mathf.Abs(angularDifference) < 2.5f)
        {
            _rigidbody.angularVelocity = 0;
            return;
        }

        _rigidbody.angularVelocity = angularDifference * _rotationSpeed;

    }
}
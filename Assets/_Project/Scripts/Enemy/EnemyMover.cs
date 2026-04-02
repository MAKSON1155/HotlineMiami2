using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _moveSpeed = 4.0f;
    private float CurrentDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    } 

    public void Move(Vector2 direction, float distanceSqr)
    {
        if (direction.sqrMagnitude < distanceSqr)
        {
            Stop();
            return;
        }

        float moveDirection = Mathf.Sign(direction.x);

        if (moveDirection != CurrentDirection)
        {
            Rotate(direction);
            CurrentDirection = moveDirection;
        }

        _rigidbody.velocity = direction.normalized * _moveSpeed;
    }

    public void Rotate(Vector2 targetPosition)
    {
        float targetAngle = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2.0f * Time.deltaTime);
    }

    public void Stop()
    {
        _rigidbody.velocity = Vector2.zero;
    }
}
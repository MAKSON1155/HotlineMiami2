using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField, Range(1.0f, 10.0f)] private float _moveSpeed = 4.0f;
    private Rigidbody2D _rigidbody;

    public bool IsMoving { get; private set; } = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction)
    {      
        if (direction.magnitude > 1.0f)
        {
            direction.Normalize();
        }

        if (direction.magnitude < 0.1f)
            direction = Vector2.zero;

        if (direction.magnitude >= 0.1)
            IsMoving = true;
        else
            IsMoving = false;

            Vector2 velocity = direction * _moveSpeed;
        _rigidbody.velocity = velocity;
    }       
}
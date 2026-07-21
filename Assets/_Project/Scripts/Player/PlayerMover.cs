using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField, Range(1.0f, 10.0f)] private float _moveSpeed = 4.0f;
    private Rigidbody2D _rigidbody;
    private Vector2 _velocity;

    public bool IsMoving { get; private set; } = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction)
    {      
        if (direction.magnitude > 1.0f)
            direction.Normalize();

        if (direction.magnitude >= 0.1f)
        {   
            IsMoving = true;
        }
        else
        {
            IsMoving = false;
            direction = Vector2.zero;
        }
   
        _velocity = direction * _moveSpeed;
        _rigidbody.velocity = _velocity;
    }       
}
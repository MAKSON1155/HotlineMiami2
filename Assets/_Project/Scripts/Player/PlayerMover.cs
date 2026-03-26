using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const float SpeedThreshold = 0.5f;

    [SerializeField, Range(1.0f, 10.0f)] private float _moveSpeed = 4.0f;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    public void Move(float xDirection, float yDirection)
    {
        Vector2 velocity = new(xDirection * _moveSpeed, yDirection * _moveSpeed);
               
        CheckMoveSpeed(ref velocity.x);
        CheckMoveSpeed(ref velocity.y);
     
        _rigidbody.velocity = velocity;
    }

    private void CheckMoveSpeed(ref float value)
    {
        if (Mathf.Abs(value) < SpeedThreshold)
            value = 0.0f;
    }
}

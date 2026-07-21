using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _direction;
    private float _speed;
    private float _angle;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector2 direction, float speed)
    {
        _direction = direction.normalized;
        _speed = speed;
        _rigidbody.velocity = _direction * _speed;

        RotateBullet();

        Destroy(gameObject, 5f);
    }

    private void RotateBullet()
    {
        _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        _angle -= 90f;
        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out IDamageable target))
        {
            target.TakeDamage();
            Destroy(gameObject);
        }
        if (collider.TryGetComponent<Wall>(out _))
            Destroy(gameObject);
    }
}
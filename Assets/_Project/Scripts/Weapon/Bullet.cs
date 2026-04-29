using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _speed;
    private Vector2 _direction;

    public void Init(Vector2 direction, float speed)
    {
        _direction = direction.normalized;
        _speed = speed;
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = _direction * _speed;

        RotateBullet();

        Destroy(gameObject, 5f);
    }

    private void RotateBullet()
    {
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        angle -= 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamageable target))
        {
            target.TakeDamage();
            Destroy(gameObject);
        }
    }
}
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private bool _isHit = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0;
    }

    public void Move(Vector2 direction, float moveSpeed)
    {
        StartCoroutine(MoveCoroutine(direction, moveSpeed));
    }

    private IEnumerator MoveCoroutine(Vector2 direction, float moveSpeed)
    {
        while (true)
        {
            _rigidbody.velocity = direction * moveSpeed;
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != gameObject)
        {
            _isHit = true;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}


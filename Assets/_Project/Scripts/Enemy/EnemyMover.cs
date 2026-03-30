using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private PatrolPoint[] _points;
    private Rigidbody2D _rigidbody;
    private float _thresholdSqr = 2.0f;
    private float _moveSpeed = 4.0f;
    private float CurrentDirection;
    private int x;
    private int _currentIndex = 0;
    private WaitForSeconds _waitingTime;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _waitingTime = new WaitForSeconds(x);
    }

    private void Start()
    {
        StartCoroutine(Patrol());
    }

    private IEnumerator Patrol()
    {
        while (true)
        {
            Vector2 targetPosition = _points[_currentIndex].transform.position;
            Vector2 direction = targetPosition - (Vector2)transform.position;

            if (direction.sqrMagnitude <= _thresholdSqr)
            {
                _currentIndex = _currentIndex++ % _points.Length;
                Stop();
                yield return _waitingTime;
                continue;
            }

            Move(direction);
            yield return null;
        }
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < _thresholdSqr)
        {
            Stop();
            return;
        }

        float moveDirection = Mathf.Sign(direction.x);

        if (moveDirection != CurrentDirection)
        {
            Rotate(moveDirection);
            CurrentDirection = moveDirection;
        }

        _rigidbody.velocity = direction.normalized * _moveSpeed;
        //IsMoving = true;
    }

    private void Rotate(float moveDirection)
    {
        transform.rotation = Quaternion.Euler(moveDirection, 0f, 0f);
    }

    private void Stop()
    {
        _rigidbody.velocity = Vector2.zero;
        //IsMoving = false;
    }
}
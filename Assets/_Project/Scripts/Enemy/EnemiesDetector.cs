using System;
using UnityEngine;

public class EnemiesDetector : MonoBehaviour
{
    public event Action<Vector2> HasDetected;

    [SerializeField] private float _radius = 5f;

    private Player _player;
    private int _collidersCount;
    private readonly Collider2D[] _results = new Collider2D[10];

    private void Update()
    {
        _collidersCount = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _results);

        for (int i = 0; i < _collidersCount; i++)
        {
            if (_results[i].TryGetComponent(out _player))
            {
                HasDetected?.Invoke(_player.transform.position);
                break;
            }         
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
using System;
using UnityEngine;

public class EnemiesDetector : MonoBehaviour
{
    public event Action<Vector2> HasDetected;

    [SerializeField] private float _radius = 15f;
    private readonly Collider2D[] _results = new Collider2D[10];

    private void FixedUpdate()
    {
        int count = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _results);

        for (int i = 0; i < count; i++)
        {
            if (_results[i].TryGetComponent(out Player player))
            {
                HasDetected?.Invoke(player.transform.position);
                break;
            }
        }
    }
}
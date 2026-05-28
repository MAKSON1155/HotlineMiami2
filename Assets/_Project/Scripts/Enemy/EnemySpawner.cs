using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemyBrain> _enemies = new ();

    public event Action HasDamaged;
    private int _enemyCount;

    private void Start()
    {
        _enemyCount = _enemies.Count;
    }

    private void OnEnable()
    {
        foreach (EnemyBrain enemy in _enemies)
            enemy.HasDamaged += RefreshEnemiesCount;
    }

    private void OnDisable()
    {
        foreach (EnemyBrain enemy in _enemies)
            enemy.HasDamaged -= RefreshEnemiesCount;
    }

    private void RefreshEnemiesCount() => _enemyCount--;

    private void Update()
    {
        if (_enemyCount <= 0)
            HasDamaged?.Invoke();
    }
}

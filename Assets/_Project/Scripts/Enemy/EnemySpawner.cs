using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemyBrain> _enemies = new();

    public event Action HasNoMore;
    private int _count;

    private void Start()
    {
        _count = _enemies.Count;
    }

    private void OnEnable()
    {
        foreach (EnemyBrain enemy in _enemies)
            enemy.HasDamaged += RefreshCount;
    }

    private void OnDisable()
    {
        foreach (EnemyBrain enemy in _enemies)
            enemy.HasDamaged -= RefreshCount;
    }

    private void RefreshCount()
    {
        _count--;
        CheckCount();
    }

    private void CheckCount()
    {     
        if (_count <= 0)         
            HasNoMore?.Invoke();
    }
}

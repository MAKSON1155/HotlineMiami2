using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public List<EnemyBrain> Enemies = new();
    public event Action HasWon;
    private int _enemiesCount => Enemies.Count;

    private void FixedUpdate()
    {
        Enemies.RemoveAll(enemy => enemy == null);


        if (_enemiesCount <= 0)
            HasWon?.Invoke();
    }
}

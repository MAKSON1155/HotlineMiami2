using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    private EnemyMover _enemyMover;
    private EnemiesDetector _detector;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
        _detector = GetComponent<EnemiesDetector>();
    }

    //private void OnEnable()
    //{
    //    _detector.HasDetected += ;
    //}

    //private void OnDisable()
    //{
    //    _detector.HasDetected -= ;
    //}

    private void FixedUpdate()
    {
        
    }
}

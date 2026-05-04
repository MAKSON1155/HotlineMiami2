using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private EnemyMover _enemyMover;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void FixedUpdate()
    {
        if (_enemyMover.IsMoving)
            _animator.SetBool("Run", true);
        else
            _animator.SetBool("Run", false);
    }
}

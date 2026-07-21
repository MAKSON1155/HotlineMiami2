using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private EnemyMover _enemyMover;
    private static readonly int RunHash = Animator.StringToHash("Run");

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void Update()
    {
        if (_enemyMover.IsMoving)
            _animator.SetBool(RunHash, true);
        else
            _animator.SetBool(RunHash, false);
    }
}

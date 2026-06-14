using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(InputReader), typeof(Rotator))]
public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _corpsePrefab;

    private PlayerMover _mover;
    private InputReader _inputReader;
    private Rotator _rotator;
    public event Action HasDamaged;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _inputReader = GetComponent<InputReader>();
        _rotator = GetComponent<Rotator>();
    }

    private void FixedUpdate()
    {
        if (_weapon != null)
        {
            if (_inputReader.GetIsShot)
                _weapon.Shot();

            if (_inputReader.GetIsReload)
                _weapon.Reload();
        }

        _rotator.Rotate(_inputReader.MousePosition);
        _mover.Move(_inputReader.MoveDirection);

        if (_mover.IsMoving)
            _animator.SetBool("Run", true);
        else
            _animator.SetBool("Run", false);
    }

    public void TakeDamage()
    {
        HasDamaged?.Invoke();
        Die();     
    }

    private void Die()
    {
        if (_corpsePrefab != null)
            Instantiate(_corpsePrefab, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(InputReader), typeof(Rotator))]
public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private Weapon _weapon;
    private PlayerMover _mover;
    private InputReader _inputReader;
    private Rotator _rotator;

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
    }

    public void TakeDamage()
    {
        Destroy(gameObject);
    }
}
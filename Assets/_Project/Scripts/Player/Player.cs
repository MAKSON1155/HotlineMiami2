using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(InputReader), typeof(Rotator))]
public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private PlayerMover _playerMover;
    private InputReader _inputReader;
    private Rotator _rotator;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _playerMover = GetComponent<PlayerMover>();
        _rotator = GetComponent<Rotator>();
        _weapon = GetComponent<Weapon>();
    }

    private void FixedUpdate()
    {
        _rotator.Rotate(_inputReader.MousePosition);

        _playerMover.Move(_inputReader.MoveDirection);

        if (_inputReader.GetIsShot)
            _weapon.Shot();

        if (_inputReader.GetIsReload)
            _weapon.Reload();
    }
}

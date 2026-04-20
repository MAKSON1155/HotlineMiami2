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
        _weapon = GetComponent<Weapon>();
        _weapon.Refresh(_weapon.Weapons[0]);
        _inputReader = GetComponent<InputReader>();
        _playerMover = GetComponent<PlayerMover>();
        _rotator = GetComponent<Rotator>();
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

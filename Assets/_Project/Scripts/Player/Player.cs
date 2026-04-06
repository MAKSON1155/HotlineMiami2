using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(InputReader), typeof(Rotator))]
public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private InputReader _inputReader;
    private Rotator _rotator;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _playerMover = GetComponent<PlayerMover>();
        _rotator = GetComponent<Rotator>();
    }

    private void Update()
    {
        _rotator.Rotate(_inputReader.MousePosition);
    }

    private void FixedUpdate()
    {
        _playerMover.Move(_inputReader.MoveDirection);
    }
}

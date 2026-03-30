using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(InputReader), typeof(PlayerRotator))]
public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private InputReader _inputReader;
    private PlayerRotator _playerRotator;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _playerMover = GetComponent<PlayerMover>();
        _playerRotator = GetComponent<PlayerRotator>();
    }

    private void Update()
    {
        _playerRotator.Rotate();
    }

    private void FixedUpdate()
    {
        _playerMover.Move(_inputReader.XDirection, _inputReader.YDirection);
    }
}

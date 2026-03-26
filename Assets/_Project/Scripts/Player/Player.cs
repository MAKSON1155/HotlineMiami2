using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(InputReader))]
public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private InputReader _inputReader;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void FixedUpdate()
    {
        _playerMover.Move(_inputReader.XDirection, _inputReader.YDirection);
    }
}

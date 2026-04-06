using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private Camera _camera;

    public Vector2 MoveDirection { get; private set; }
    public Vector2 MousePosition { get; private set; }

    private void Update()
    {
        MoveDirection = new(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));

        MousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
    }
}
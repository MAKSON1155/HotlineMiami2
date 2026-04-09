using UnityEngine;

public class InputReader : MonoBehaviour
{
    public bool GetIsShot => GetBoolAsTrigger(ref _isShot);
    public bool GetIsReload => GetBoolAsTrigger(ref _isReload);

    public Vector2 MoveDirection { get; private set; }
    public Vector2 MousePosition { get; private set; }

    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const KeyCode KeyShot = KeyCode.Mouse0;
    private const KeyCode KeyReload = KeyCode.R;

    [SerializeField] private Camera _camera;

    private bool _isShot;
    private bool _isReload;

    private void Update()
    {
        MoveDirection = new(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));
        MousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKey(KeyShot))
            _isShot = true;

        if (Input.GetKey(KeyReload))
            _isReload = true;
    }

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool trigger = value;
        value = false;
        return trigger;
    }
}
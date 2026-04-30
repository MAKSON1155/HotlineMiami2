using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const KeyCode KeyShot = KeyCode.Mouse0;
    private const KeyCode KeyReload = KeyCode.R;

    [SerializeField] private Camera _camera;

    private bool _isShot;
    private bool _isReload;

    public Vector2 MoveDirection { get; private set; }
    public Vector2 MousePosition { get; private set; }

    public bool GetIsShot => GetBoolAsTrigger(ref _isShot);
    public bool GetIsReload => GetBoolAsTrigger(ref _isReload);

    private void Update()
    {
        MoveDirection = new(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));

        if (_camera != null)
        {
            Vector3 mousePos = Input.mousePosition;

            if (mousePos.x >= 0 && mousePos.x <= Screen.width && mousePos.y >= 0 && mousePos.y <= Screen.height)
                MousePosition = _camera.ScreenToWorldPoint(mousePos);
        }

        if (Input.GetKey(KeyShot))
            _isShot = true;

        if (Input.GetKeyDown(KeyReload))
            _isReload = true;
    }

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool trigger = value;
        value = false;
        return trigger;
    }
}
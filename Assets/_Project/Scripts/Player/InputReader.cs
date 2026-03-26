using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    public float XDirection { get; private set; }

    public float YDirection { get; private set; }

    private void Update()
    {
        XDirection = Input.GetAxis(Horizontal);
        YDirection = Input.GetAxis(Vertical);
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        return mousePosition;
    }
}

using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    public float XDirection { get; private set; }

    public float YDirection { get; private set; }

    private void Update()
    {
        XDirection = Input.GetAxis(Horizontal);
        YDirection = Input.GetAxis(Vertical);
    }
}

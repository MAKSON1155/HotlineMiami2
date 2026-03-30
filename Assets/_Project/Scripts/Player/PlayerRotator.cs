using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class PlayerRotator : MonoBehaviour
{
   [SerializeField] private float _rotationSpeed = 10f;
    private InputReader _inputReader;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
    }

    public void Rotate()
    {
        Vector2 direction = (_inputReader.GetMousePosition() - transform.position).normalized;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}

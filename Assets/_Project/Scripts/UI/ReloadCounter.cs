using System.Collections;
using TMPro;
using UnityEngine;

public class ReloadCounter : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private TextMeshProUGUI _text;
    private float _duration;
    private float _elapsedTime;
    private string _count;
    private Coroutine _current;

    private void Awake()
    {
        _duration = _weapon.ReloadTime;
    }
    private void Update()
    {
        if (_weapon.IsReload)
            StartCount();
        else
            _text.text = " ";
    }
    public void StartCount() => _current ??= StartCoroutine(CountRoutine());

    private IEnumerator CountRoutine()
    {
        _elapsedTime = 0.0f;
        while (_elapsedTime < _duration)
        {
            _elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(_elapsedTime / _duration);
            float currentValue = Mathf.Lerp(_duration, 0.0f, t);

            _text.text = $"Reloading: {currentValue.ToString("F1")}";
            yield return null;
        }

        StopCoroutine(CountRoutine());
        _current = null;
    }
}

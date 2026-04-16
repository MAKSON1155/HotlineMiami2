using System;
using System.Collections;
using UnityEngine;

public class EnemiesDetector : MonoBehaviour
{
    public event Action<Vector2> HasDetected;

    [SerializeField] private  float _radius = 15f;
    private WaitForSeconds _sleep;
    private Collider2D[] _colliders;

    private void Awake()
    {
        _sleep = new WaitForSeconds(0.1f);
    }

    private void Start()
    {
        StartCoroutine(Overlap());
    }

    private IEnumerator Overlap()
    {
        while (true)
        {       
            yield return _sleep;
        
            _colliders = Physics2D.OverlapCircleAll(transform.position, _radius);
            
            foreach (Collider2D collider in _colliders)        
                if (collider.gameObject.TryGetComponent(out Player target))              
                    HasDetected?.Invoke(target.transform.position);
        }
    }
}

using UnityEngine;

public class Corpse : MonoBehaviour, IDamageable
{
    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    public void TakeDamage() => Destroy(gameObject);
}

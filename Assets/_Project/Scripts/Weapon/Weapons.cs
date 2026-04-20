using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Game/Weapon")]
public class Weapons : ScriptableObject
{
    [field: SerializeField] public int ClipMaxSize { get; private set; }

    [field: SerializeField] public float _gunRateDelay { get; private set; }

    [field: SerializeField] public float _reloadTime { get; private set; }

    [field: SerializeField] public float _bulletSpeed { get; private set; }

    [field: SerializeField] public Bullet _bulletPrefab { get; private set; }

    [field: SerializeField] public WeaponTypes _active { get; private set; }
}
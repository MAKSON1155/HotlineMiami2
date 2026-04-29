using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Game/Weapon")]
public class WeaponData : ScriptableObject
{
    [field: SerializeField] public int ClipMaxSize { get; private set; }
    [field: SerializeField] public float GunRateDelay { get; private set; }
    [field: SerializeField] public float ReloadTime { get; private set; }
    [field: SerializeField] public float BulletSpeed { get; private set; }
    [field: SerializeField] public Bullet BulletPrefab { get; private set; }
    [field: SerializeField] public WeaponType Type { get; private set; }
}
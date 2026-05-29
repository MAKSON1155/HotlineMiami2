using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rotator))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData _data;
    [SerializeField] private Transform _firePoint;
    private int _currentAmmo;
    private float _lastShotTime;
    private Rotator _rotator;
    private Coroutine _current;
    private WaitForSeconds _reload;

    private void Start()
    {
        _reload = new (_data.ReloadTime);
        if (_data == null)
            return;

        _currentAmmo = _data.ClipMaxSize;
        _rotator = GetComponent<Rotator>();
    }

    public void Shot()
    {
        if (_data == null)
            return;

        if (Time.time < _lastShotTime + _data.GunRateDelay)
            return;

        if (_currentAmmo <= 0)
        {
            //Reload();
            return;
        }

        Vector2 shootDirection = GetShootDirection();

        if (shootDirection == Vector2.zero)
            return;

        ShootAtDirection(shootDirection);
    }

    public void ShootAtDirection(Vector2 direction)
    {
        if (_data == null)
            return;

        if (_currentAmmo <= 0)
        {
            //Reload();
            return;
        }

        if (_firePoint == null)
            return;

        var bullet = Instantiate(_data.BulletPrefab, _firePoint.position, Quaternion.identity);
        bullet.Init(direction, _data.BulletSpeed);
        _currentAmmo--;
        _lastShotTime = Time.time;
    }

    private Vector2 GetShootDirection()
    {
        if (_rotator != null && _rotator.Direction != Vector2.zero)
            return _rotator.Direction;

        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mouseWorldPos - _firePoint.position).normalized;
            if (direction != Vector2.zero)
                return direction;
        }

        return Vector2.right;
    }

    public void Reload()
    {
        if (_data == null)
            return;

        if (_currentAmmo == _data.ClipMaxSize)
            return;

        _current ??= StartCoroutine(ReloadCoroutine());      
    }

    private IEnumerator ReloadCoroutine()
    {
        yield return _reload;
        StopCoroutine(ReloadCoroutine());
        _current = null;
        _currentAmmo = _data.ClipMaxSize;
    }
}
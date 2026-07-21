using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rotator))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData _data;
    [SerializeField] private Transform _firePoint;

    private Coroutine _current;
    private WaitForSeconds _reload;
    private Camera _mainCamera;
    private int _currentAmmo;
    private float _lastShotTime;

    private void Start()
    {
        if (_data == null)
            return;

        _reload = new(_data.ReloadTime);
        _currentAmmo = _data.ClipMaxSize;
        _mainCamera = Camera.main;
    }

    public void ShotByMouseDirection()
    {
        if (Time.time < _lastShotTime + _data.GunRateDelay)
            return;

        if (_currentAmmo <= 0)
        {
            Reload();
            Debug.Log("перезарядка(авто)");
            return;
        }

        Vector2 shootDirection = GetMouseDirection();

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
            Reload();
            return;
        }

        if (_firePoint == null)
            return;

        var bullet = Instantiate(_data.BulletPrefab, _firePoint.position, Quaternion.identity);
        bullet.Init(direction, _data.BulletSpeed);
        _currentAmmo--;
        _lastShotTime = Time.time;
    }

    private Vector2 GetMouseDirection()
    {  
        if (_mainCamera != null)
        {
            Vector3 mouseWorldPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mouseWorldPos - _firePoint.position).normalized;

            if (direction != Vector2.zero)
                return direction;
        }

        return Vector2.right;
    }

    public void Reload()
    {
        if (_currentAmmo == _data.ClipMaxSize)
            return;

        _current ??= StartCoroutine(ReloadCoroutine());      
    }

    private IEnumerator ReloadCoroutine()
    {
        yield return _reload;
        _currentAmmo = _data.ClipMaxSize;

        StopCoroutine(ReloadCoroutine());
        _current = null;
    }
}
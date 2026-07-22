using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rotator))]
public class Weapon : MonoBehaviour
{
    public int CurrentAmmo => _currentAmmo;
    public bool IsReload => _isReload;
    public float ReloadTime => _data.ReloadTime;

    [SerializeField] private WeaponData _data;
    [SerializeField] private Transform _firePoint;

    private Coroutine _current;
    private WaitForSeconds _reloadTime;
    private Camera _mainCamera;
    private int _currentAmmo;
    private bool _isReload;
    private float _lastShotTime;

    private void Start()
    {
        if (_data == null)
            return;

        _reloadTime = new(_data.ReloadTime);
        _currentAmmo = _data.ClipMaxSize;
        _mainCamera = Camera.main;
    }

    public void ShotByMouseDirection()
    {
        if (_isReload) return;

        if (Time.time < _lastShotTime + _data.GunRateDelay)
            return;

        if (_currentAmmo <= 0)
        {
            Reload();
            return;
        }

        Vector2 shootDirection = GetMouseDirection();

        if (shootDirection == Vector2.zero)
            return;

        ShootAtDirection(shootDirection);
    }

    public void ShootAtDirection(Vector2 direction)
    {
        if (_isReload) return;

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
        if (_isReload) return;

        if (_currentAmmo == _data.ClipMaxSize)
            return;

        _current ??= StartCoroutine(ReloadCoroutine());      
    }

    private IEnumerator ReloadCoroutine()
    {
        _isReload = true;
        yield return _reloadTime;
        _currentAmmo = _data.ClipMaxSize;

        StopCoroutine(ReloadCoroutine());
        _current = null;
        _isReload = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rotator))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private int _clipMaxSize;
    [SerializeField] private float _gunRateDelay;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private GameObject _position;

    [SerializeField] public List<Weapons> Weapons;
    private Weapons _active;

    private int _clipCurrentSize;
    private Coroutine _shotCoroutine;
    private Coroutine _reloadCoroutine;
    private WaitForSeconds _waitGunRate;
    private WaitForSeconds _waitReload;
    private Rotator _rotator;

    private void Awake()
    {
        _active = Weapons[0];        
        _rotator = GetComponent<Rotator>();
    }

    private void Start()
    {
        _clipCurrentSize = _clipMaxSize;
        _waitGunRate = new WaitForSeconds(_gunRateDelay);
        _waitReload = new WaitForSeconds(_reloadTime);
    }

    public void Shot()
    {
        if (_clipCurrentSize <= 0)
        {
            Reload();
            return;
        }

        if (_clipCurrentSize > 0)
            _shotCoroutine ??= StartCoroutine(DelayCoroutine());
    }

    public void Reload()
    {
        if (_clipCurrentSize >= _clipMaxSize)
            return;

        _reloadCoroutine ??= StartCoroutine(ReloadCoroutine());
    }

    public void Refresh(Weapons weapon)
    {
        _clipMaxSize = weapon.ClipMaxSize;
        _gunRateDelay = weapon._gunRateDelay;
        _reloadTime = weapon._reloadTime;
        _bulletSpeed = weapon._bulletSpeed;
        _active = weapon;
    }

    private IEnumerator DelayCoroutine()
    {
        Bullet bullet = Instantiate(_bulletPrefab, _position.transform.position, Quaternion.identity);
        bullet.Move(_rotator.Direction, _bulletSpeed);
        _clipCurrentSize--;
        yield return _waitGunRate;

        StopCoroutine(_shotCoroutine);
        _shotCoroutine = null;
    }

    private IEnumerator ReloadCoroutine()
    {
        yield return _waitReload;

        _clipCurrentSize = _clipMaxSize;
        StopCoroutine(_reloadCoroutine);
        _reloadCoroutine = null;
    }
}
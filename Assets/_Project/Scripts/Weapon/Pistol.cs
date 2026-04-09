using System.Collections;
using UnityEngine;

public class Pistol : Weapon
{
    private void Awake()
    {
        _clipCurrentSize = _clipMaxSize;

        _waitGunRate = new WaitForSeconds(_gunRateDelay);
        _waitReload = new WaitForSeconds(_reloadTime);
    }

    public override void Shot()
    {
        if (_clipCurrentSize <= 0)
        {
            Reload();
            return;
        }

        if (_clipCurrentSize > 0)
            _shotCoroutine ??= StartCoroutine(DelayCoroutine());
    }

    public override void Reload()
    {
        if (_clipCurrentSize >= _clipMaxSize)
            return;

        _reloadCoroutine ??= StartCoroutine(ReloadCoroutine());
    }

    protected override IEnumerator DelayCoroutine()
    {
        Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        _clipCurrentSize--;

        yield return _waitGunRate;

        _shotCoroutine = null;
    }

    protected override IEnumerator ReloadCoroutine()
    {
        yield return _waitReload;

        _clipCurrentSize = _clipMaxSize;

        _reloadCoroutine = null;
    }
}


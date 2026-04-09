using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int _clipMaxSize;
    [SerializeField] protected float _gunRateDelay;
    [SerializeField] protected float _reloadTime;
    [SerializeField] protected Bullet _bulletPrefab;

    protected Coroutine _shotCoroutine;
    protected Coroutine _reloadCoroutine;
    protected WaitForSeconds _waitGunRate;
    protected WaitForSeconds _waitReload;
    protected int _clipCurrentSize;

    public abstract void Shot();

    public abstract void Reload();

    protected abstract IEnumerator DelayCoroutine();

    protected abstract IEnumerator ReloadCoroutine();
}
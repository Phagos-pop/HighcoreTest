using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    protected const float BulletSpeed = 50f;

    [SerializeField] protected WeaponType _type;

    protected float _damage;
    protected float _rate;
    protected float _range;
    protected float _rangeFire;
    protected float _reloadTime;
    protected int _clip;
    protected bool _isCanShoot => !_isReload && _canShoot;

    private bool _isInitialized;
    private bool _canShoot;
    private bool _isReload;
    private int _currentClip;

    public bool IsInitialized => _isInitialized;

    public WeaponType Type => _type;

    public virtual void Init(GunFeatureContainerItem item)
    {
        _damage = item.Damage;
        _rate = item.Rate;
        _range = item.Range;
        _rangeFire = item.RangeFire;
        _reloadTime = item.ReloadTime;
        _clip = item.Clip;

        _isInitialized = true;
        _canShoot = true;

        _currentClip = _clip;
    }

    public async virtual UniTask Reload()
    {
        _isReload = true;
        await UniTask.Delay(TimeSpan.FromSeconds(_reloadTime));
        _isReload = false;
        _canShoot = true;
        _currentClip = _clip;
    }

    public virtual void Shoot(Vector3 direction)
    {
        RateDelay();
        if (_currentClip == 0)
        {
            Reload();
        }
    }

    protected Vector3 GetDirection(Vector3 direction)
    {
        direction = new Vector3(
            direction.x + Random.Range(0, 1 - _rangeFire) * Random.Range(-direction.x, direction.x),
            direction.y + Random.Range(0, 1 - _rangeFire) * Random.Range(-direction.y, direction.y),
            direction.z + Random.Range(0, 1 - _rangeFire) * Random.Range(-direction.z, direction.z));

        return direction;
    }

    private async void RateDelay()
    {
        _canShoot = false;
        _currentClip--;
        await UniTask.Delay(TimeSpan.FromSeconds(_rate));
        _canShoot = true;
    }
}

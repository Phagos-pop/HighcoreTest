using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponType _type;

    protected float Damage;
    protected float Rate;
    protected float Range;
    protected float RangeFire;
    protected float ReloadTime;
    protected int Clip;

    public WeaponType Type => _type;

    public void Init()
    {

    }

    public virtual void Reload()
    {

    }

    public virtual void Shoot()
    {

    }
}

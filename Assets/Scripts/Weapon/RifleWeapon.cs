using UnityEngine;

namespace Test.Weapon
{
    public class RifleWeapon : BaseWeapon
    {
        [SerializeField] private BaseBullet _bulletPrefab;
        [SerializeField] private Transform _bulletPoint;

        public override void Shoot(Vector3 direction)
        {
            if (!_isCanShoot)
                return;
            base.Shoot(direction);
            var bullet = Instantiate(_bulletPrefab, _bulletPoint.position, Quaternion.identity);
            bullet.Init(_damage);
            direction = GetDirection(direction);
            bullet.Shoot(direction, BulletSpeed, _range);
        }
    }
}
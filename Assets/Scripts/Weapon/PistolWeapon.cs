using UnityEngine;

namespace Test.Weapon
{
    public class PistolWeapon : BaseWeapon
    {
        private const float Duration = 2f;
        private const int Ticks = 5;

        [SerializeField] private ShockBullet _bulletPrefab;
        [SerializeField] private Transform _bulletPoint;

        public override void Shoot(Vector3 direction)
        {
            if (!_isCanShoot)
                return;
            base.Shoot(direction);
            var bullet = Instantiate(_bulletPrefab, _bulletPoint.position, Quaternion.identity);
            bullet.Init(_damage);
            bullet.SetAddedParametres(_damage, Duration, Ticks);
            direction = GetDirection(direction);
            bullet.Shoot(direction, BulletSpeed, _range);
        }
    }
}
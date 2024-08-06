using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Test.Weapon
{
    public interface IWeapon
    {
        public void Shoot(Vector3 direction);
        public UniTask Reload();
        public void Init(GunFeatureContainerItem item);
    }
}
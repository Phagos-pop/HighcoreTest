using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IWeapon
{
    public void Shoot(Vector3 direction);
    public UniTask Reload();
    public void Init(GunFeatureContainerItem item);
}

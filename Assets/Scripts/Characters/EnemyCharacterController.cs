using System.Collections.Generic;
using System.Linq;
using Test.Weapon;
using UnityEngine;

namespace Test.Character
{
    public class EnemyCharacterController
    {
        private AllServices _allServices;

        private List<EnemyCharacter> _enemyCharacters;
        private List<BaseWeapon> _weapons;

        public void Init()
        {
            _allServices = AllServices.Container;

            GetCharacters();
        }

        private void GetCharacters()
        {
            _enemyCharacters = _allServices.EnemyCharacters;
            _weapons = _allServices.Weapons;
            var mainCharacter = _allServices.MainCharacter;

            foreach (var item in _enemyCharacters)
            {
                var weapon = _weapons[Random.Range(0, _weapons.Count - 1)];
                weapon = Object.Instantiate(weapon, item.transform);
                weapon.transform.SetPositionAndRotation(item.GunTranform.position, item.GunTranform.rotation);
                var feature = _allServices.GunContainer.gunFeatures.FirstOrDefault(p => p.Type == weapon.Type);
                weapon.Init(feature);
                weapon.gameObject.SetActive(true);
                item.OnDestroy += CharacterOnApplyDamage;
                item.Init(
                    weapon, 
                    mainCharacter, 
                    _allServices.EnemyCharacterContainer.shootDelay,
                    _allServices.EnemyCharacterContainer.healthPoint
                    );
            }
        }

        private void CharacterOnApplyDamage(EnemyCharacter character)
        {
            _enemyCharacters.Remove(character);
        }
    }
}

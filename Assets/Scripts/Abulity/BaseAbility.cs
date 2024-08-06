using System.Collections;
using System.Collections.Generic;
using Test.Character;
using UnityEngine;

namespace Test.Abuility
{
    public class BaseAbility : IAbulity
    {
        private float _damage;
        private DamageType _damageType;

        public BaseAbility(float damage, DamageType damageType)
        {
            _damage = damage;
            _damageType = damageType;
        }

        public void ApplyDamage(IDamageableCharacter character)
        {
            character.TakeDamage(_damageType, _damage);
        }

        public float GetDamage()
        {
            return _damage;
        }

        public DamageType GetDamageType()
        {
            return DamageType.Physics;
        }
    }
}
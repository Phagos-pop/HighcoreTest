using Test.Abuility;
using UnityEngine;

namespace Test.Character
{
    public abstract class BaseCharacter : MonoBehaviour, IDamageableCharacter
    {
        public abstract void TakeDamage(DamageType type, float value);
    }
}

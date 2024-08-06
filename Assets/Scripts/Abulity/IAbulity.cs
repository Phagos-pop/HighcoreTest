using Test.Character;

namespace Test.Abuility
{
    public interface IAbulity
    {
        public float GetDamage();
        public DamageType GetDamageType();
        public void ApplyDamage(IDamageableCharacter character);
    }
}
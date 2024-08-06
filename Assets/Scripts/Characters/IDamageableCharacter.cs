using Test.Abuility;

namespace Test.Character
{
    public interface IDamageableCharacter
    {
        public void TakeDamage(DamageType type, float value);
    }
}

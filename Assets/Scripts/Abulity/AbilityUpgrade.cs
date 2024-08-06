using Test.Character;

namespace Test.Abuility
{
    public abstract class AbilityUpgrade : IAbulity
    {
        protected IAbulity _mainAbility;

        public AbilityUpgrade(IAbulity mainAbility)
        {
            _mainAbility = mainAbility;
        }

        public virtual void ApplyDamage(IDamageableCharacter character)
        {
            _mainAbility.ApplyDamage(character);
        }

        public virtual float GetDamage()
        {
            return _mainAbility.GetDamage();
        }

        public virtual DamageType GetDamageType()
        {
            return _mainAbility.GetDamageType();
        }
    }
}

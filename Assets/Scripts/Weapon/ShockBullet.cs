using Test.Abuility;
using Test.Character;

namespace Test.Weapon
{
    public class ShockBullet : BaseBullet
    {
        private float _addedDamage;
        private float _duration;
        private int _ticks;

        public void SetAddedParametres(float damage, float duration, int ticks)
        {
            _addedDamage = damage;
            _duration = duration;
            _ticks = ticks;
        }

        protected override void UseAbility(IDamageableCharacter character)
        {
            base.UseAbility(character);
            _ability = new AdditionalAbility(_ability, _addedDamage, DamageType.Shock, _duration, _ticks);
        }
    }
}

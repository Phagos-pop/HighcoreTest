using Test.Character;
using Cysharp.Threading.Tasks;
using System;

namespace Test.Abuility
{
    public class AdditionalAbility : AbilityUpgrade
    {
        private float _additionDamage;
        private DamageType _additionDamageType;
        private float _duration;
        private int _ticks;

        public AdditionalAbility(
            IAbulity abulity, 
            float additionDamage,
            DamageType damageType, 
            float duration,
            int ticks) : base(abulity) 
        {
            _additionDamage = additionDamage;
            _additionDamageType = damageType;
            _duration = duration;
            _ticks = ticks;
        }

        public async override void ApplyDamage(IDamageableCharacter character)
        {
            base.ApplyDamage(character);

            var currentDuration = _duration;

            while (currentDuration >= 0)
            {
                currentDuration -= _duration / _ticks;
                character.TakeDamage(_additionDamageType, _additionDamage / _ticks);
                await UniTask.Delay(TimeSpan.FromSeconds(_duration / _ticks));
            }
        }
    }
}

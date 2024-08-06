using Test.Abuility;
using Cysharp.Threading.Tasks;
using Test.Character;
using UnityEngine;

namespace Test.Weapon
{
    [RequireComponent(typeof(Rigidbody))]
    public class BaseBullet : MonoBehaviour
    {
        private float _damage;
        private Rigidbody _rigidbody;
        private Vector3 _startPosition;
        private bool _destroyed;

        protected IAbulity _ability;

        public void Init(float damage)
        {
            _damage = damage;
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_destroyed)
                return;

            if (collision.gameObject.TryGetComponent<BaseCharacter>(out var character))
            {
                UseAbility(character);
                _ability.ApplyDamage(character);
            }

            Destroy(this.gameObject);
            _destroyed = true;
        }

        protected virtual void UseAbility(IDamageableCharacter character)
        {
            _ability = new BaseAbility(_damage, DamageType.Physics);
        }

        public async void Shoot(Vector3 direction, float speed, float distance)
        {
            _startPosition = transform.position;
            direction = direction * speed;
            _rigidbody.AddForce(direction, ForceMode.Impulse);

            while (Vector3.Distance(_startPosition, transform.position) < distance)
            {
                await UniTask.NextFrame();
                if (_destroyed)
                {
                    return;
                }
            }

            if (gameObject != null)
            {
                Destroy(this.gameObject);
            }
        }
    }
}

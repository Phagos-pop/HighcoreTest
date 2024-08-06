using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Test.Abuility;
using Test.Weapon;

namespace Test.Character
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyCharacter : BaseCharacter
    {
        private const float Step = 2f;
        private const float MoveTime = 2f;

        [SerializeField] private Transform _gunTranform;

        private BaseWeapon _weapon;
        private MainCharacter _mainCharacter;
        private float _shootDelay;
        private float _healthPoint;
        private bool _canShoot;
        private bool _isDestroyed;
        private TweenerCore<Vector3, Vector3, VectorOptions> _tween;

        public Transform GunTranform => _gunTranform;
        public event Action<EnemyCharacter> OnDestroy;

        public void Init(BaseWeapon weapon, MainCharacter mainCharacter, float shootDelay, float healthPoint)
        {
            _weapon = weapon;
            _mainCharacter = mainCharacter;
            _shootDelay = shootDelay;
            _healthPoint = healthPoint;
            StartActing();
        }

        private async void StartActing()
        {
            _canShoot = true;

            while (_canShoot)
            {
                var direction = Vector3.Normalize(_mainCharacter.transform.position - transform.position);
                _weapon.Shoot(direction);
                var vectorTOMove = new Vector3(Random.Range(-Step, Step), 0f, Random.Range(-Step, Step)) + transform.position;
                _tween = transform.DOMove(vectorTOMove, MoveTime).SetEase(Ease.OutSine);
                transform.LookAt(_mainCharacter.transform);
                await UniTask.Delay(TimeSpan.FromSeconds(_shootDelay));
            }
        }

        private void Destroy()
        {
            _canShoot = false;
            _tween.Kill();
            _isDestroyed = true;
            Destroy(gameObject);
        }

        public override void TakeDamage(DamageType type, float value)
        {
            if (_isDestroyed)
                return;

            Debug.Log($"type {type}, value {value}");

            _healthPoint -= value;

            if (_healthPoint < 0)
            {
                OnDestroy?.Invoke(this);
                Destroy();
            }
        }
    }
}
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

[RequireComponent(typeof(Rigidbody))]
public class EnemyCharacter : Character
{
    private const float Step = 2f;
    private const float MoveTime = 2f;

    [SerializeField] private Transform _gunTranform;

    private Weapon _weapon;
    private MainCharacter _mainCharacter;
    private float _shootDelay;
    private bool _canShoot;
    private TweenerCore<Vector3, Vector3, VectorOptions> _tween;

    public Transform GunTranform => _gunTranform;
    public event Action<EnemyCharacter, float> OnApplyDamage;

    public void Init(Weapon weapon, MainCharacter mainCharacter, float shootDelay)
    {
        _weapon = weapon;
        _mainCharacter = mainCharacter;
        _shootDelay = shootDelay;
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

    public void Destroy()
    {
        _canShoot = false;
        _tween.Kill();
        Destroy(gameObject);
    }

    public override void ApplyDamage(float value)
    {
        OnApplyDamage?.Invoke(this, value);
    }
}

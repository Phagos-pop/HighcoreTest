using Cysharp.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private const float TimeToDestroy = 10f;

    private float _damage;
    private Rigidbody _rigidbody;
    private Vector3 _startPosition;
    private bool _destroyed;

    public void Init(float damage)
    {
        _damage = damage;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_destroyed)
            return;

        if (collision.gameObject.TryGetComponent<Character>(out var character))
        {
            character.ApplyDamage(_damage);
        }

        Destroy(this.gameObject);
        _destroyed = true;
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

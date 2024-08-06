using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MainCharacter : Character
{
    [SerializeField] private List<Weapon> _weapons;

    private Rigidbody _rigidbody;

    private float _speedMove;
    private Vector3 _moveVector;
    private Vector3 _rotateVector;

    public event Action<float> OnApplyDamage;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    public void Init(float speedMove)
    {
        _speedMove = speedMove;
    }

    public void SetMovement(Vector3 vector)
    {
        _moveVector = vector;
    }

    public void SetRotation(float angle)
    {
        _rotateVector += angle * Vector3.up;
    }

    private void Rotate()
    {
        _rigidbody.rotation = Quaternion.Euler(_rotateVector);
    }

    private void Move()
    {
        if (_moveVector.sqrMagnitude < 0.05f)
        {
            _rigidbody.velocity = Vector3.zero;
            return;
        }

        _rigidbody.AddRelativeForce(_speedMove * Time.fixedDeltaTime * _moveVector, ForceMode.Impulse);

        _moveVector = Vector3.zero;
    }

    public override void ApplyDamage(float value)
    {
        OnApplyDamage?.Invoke(value);
    }
}

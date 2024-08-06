using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Test.Weapon;

namespace Test.Character
{
    public class MainCharacterController : IDisposable
    {
        private AllServices _allServices;
        private IInputService _inputService;

        private MainCharacter _mainCharacter;
        private List<BaseWeapon> _weapons;
        private BaseWeapon _currentWeapon;
        private float _characterSpeed;
        private float _characterHP;

        public void Init()
        {
            _allServices = AllServices.Container;

            GetCharacter();

            GetWeapon();

            GetInput();
        }

        private void GetInput()
        {
            _inputService = _allServices.InputService;

            _inputService.OnClickMovementButton += OnClickMovementButtonHandler;
            _inputService.OnClickNumberButton += OnClickNumberButtonHandler;
            _inputService.OnMouseButtonDown += OnMouseButtonDownHandler;
            _inputService.OnMouseButtonHold += OnMouseButtonHoldHandler;
            _inputService.OnMouseButtonUp += OnMouseButtonUpHandler;
        }

        private void GetCharacter()
        {
            _mainCharacter = _allServices.MainCharacter;
            _mainCharacter.OnApplyDamage += CharacterApplyDamage;
            _characterHP = _allServices.CharacterContainer.Healthpoint;
            _characterSpeed = _allServices.CharacterContainer.Speed;
            _mainCharacter.Init(_characterSpeed);
        }

        private void CharacterApplyDamage(float value)
        {
            _characterHP = -value;
            if (_characterHP < 0)
            {
                _mainCharacter.OnApplyDamage -= CharacterApplyDamage;
            }
        }

        private void GetWeapon()
        {
            _weapons = _allServices.Weapons;
            foreach (var item in _weapons)
            {
                var feature = _allServices.GunContainer.gunFeatures.FirstOrDefault(p => p.Type == item.Type);
                item.Init(feature);
                item.gameObject.SetActive(false);
            }

            _currentWeapon = _weapons[0];
            _currentWeapon.gameObject.SetActive(true);
        }

        private void OnMouseButtonUpHandler(Vector3 position)
        {

        }

        private void OnMouseButtonHoldHandler(Vector3 position)
        {
            if (_currentWeapon.Type == WeaponType.Rifle)
            {
                return;
            }

            var screen = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            var ray = Camera.main.ScreenPointToRay(screen);
            var direction = ray.direction;
            _currentWeapon.Shoot(direction);
        }

        private void OnMouseButtonDownHandler(Vector3 position)
        {
            if (_currentWeapon.Type != WeaponType.Rifle)
            {
                return;
            }

            var screen = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            var ray = Camera.main.ScreenPointToRay(screen);
            var direction = ray.direction;
            _currentWeapon.Shoot(direction);
        }

        private void OnClickNumberButtonHandler(int value)
        {
            foreach (var item in _weapons)
            {
                item.gameObject.SetActive(false);
            }
            _currentWeapon = _weapons[value - 1];
            _currentWeapon.gameObject.SetActive(true);
        }

        private void OnClickMovementButtonHandler(MovementType type)
        {
            var vector = Vector3.zero;

            if (type.HasFlag(MovementType.Left))
            {
                vector += Vector3.left;
            }

            if (type.HasFlag(MovementType.Right))
            {
                vector += Vector3.right;
            }

            if (type.HasFlag(MovementType.Back))
            {
                vector += Vector3.back;
            }

            if (type.HasFlag(MovementType.Forward))
            {
                vector += Vector3.forward;
            }

            if (Mathf.Abs(vector.x) == 1 && Mathf.Abs(vector.z) == 1)
            {
                vector.x = vector.x / 1.41f;
                vector.z = vector.z / 1.41f;
            }

            _mainCharacter.SetMovement(vector);
        }

        public void Dispose()
        {
            _inputService.OnClickMovementButton -= OnClickMovementButtonHandler;
            _inputService.OnClickNumberButton -= OnClickNumberButtonHandler;
            _inputService.OnMouseButtonDown -= OnMouseButtonDownHandler;
            _inputService.OnMouseButtonHold -= OnMouseButtonHoldHandler;
            _inputService.OnMouseButtonUp -= OnMouseButtonUpHandler;
            _mainCharacter.OnApplyDamage -= CharacterApplyDamage;
        }
    }
}

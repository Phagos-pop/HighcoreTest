using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : ICharacterController
{
    private const float CharacterSpeed = 10f;

    private AllServices _allServices;
    private IInputService _inputService;

    private MainCharacter _mainCharacter;

    public void Init(MainCharacter mainCharacter)
    {
        _mainCharacter = mainCharacter;
        _mainCharacter.Init(CharacterSpeed);

        _allServices = AllServices.Container;
        _inputService = _allServices.InputService;

        _inputService.OnClickMovementButton += OnClickMovementButtonHandler;
        _inputService.OnClickNumberButton += OnClickNumberButtonHandler;
        _inputService.OnMouseButtonDown += OnMouseButtonDownHandler;
        _inputService.OnMouseButtonHold += OnMouseButtonHoldHandler;
        _inputService.OnMouseButtonUp += OnMouseButtonUpHandler;
    }

    private void OnMouseButtonUpHandler(Vector3 position)
    {
        
    }

    private void OnMouseButtonHoldHandler(Vector3 position)
    {
        
    }

    private void OnMouseButtonDownHandler(Vector3 position)
    {
        
    }

    private void OnClickNumberButtonHandler(int value)
    {
        
    }

    private void OnClickMovementButtonHandler(MovementType type)
    {
        var vector = Vector3.zero;

        switch (type)
        {
            case MovementType.Left:
                vector = Vector3.left;
                break;
            case MovementType.Right:
                vector = Vector3.right;
                break;
            case MovementType.Forward:
                vector = Vector3.forward;
                break;
            case MovementType.Back:
                vector = Vector3.back;
                break;
            default:
                break;
        }

        _mainCharacter.SetMovement(vector);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private MainCharacter _mainCharacter;

    private AllServices _allServices;
    private CharacterController _characterController;

    private void Start()
    {
        _allServices = AllServices.Container;
        _characterController = new CharacterController();
        _characterController.Init(_mainCharacter);
    }
}

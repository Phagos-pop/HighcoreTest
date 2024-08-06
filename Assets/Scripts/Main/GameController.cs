using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private CharacterController _characterController;
    private EnemyCharacterController _enemyCharacterController;

    private void Start()
    {
        _characterController = new CharacterController();
        _characterController.Init();
        _enemyCharacterController = new EnemyCharacterController();
        _enemyCharacterController.Init();
    }
}

using Test.Character;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private MainCharacterController _characterController;
    private EnemyCharacterController _enemyCharacterController;

    private void Start()
    {
        _characterController = new MainCharacterController();
        _characterController.Init();
        _enemyCharacterController = new EnemyCharacterController();
        _enemyCharacterController.Init();
    }
}

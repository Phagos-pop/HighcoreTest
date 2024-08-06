using System.Collections.Generic;
using Test.Character;
using Test.Weapon;
using UnityEngine;

public class AllServices : MonoBehaviour
{
    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this);
    }

    private static AllServices _instance;

    public static AllServices Container => _instance;

    [SerializeField] private InputService _inputService;
    [SerializeField] private MainCharacter _mainCharacter;
    [SerializeField] private List<BaseWeapon> _weapons;
    [SerializeField] private GunFeatureContainer _gunContainer;
    [SerializeField] private CharacterContainer _characterContainer;
    [SerializeField] private EnemyCharacterContainer _enemyCharacterContainer;
    [SerializeField] private List<EnemyCharacter> _enemyCharacters;

    public IInputService InputService => _inputService;
    public MainCharacter MainCharacter => _mainCharacter;
    public List<BaseWeapon> Weapons => _weapons;
    public GunFeatureContainer GunContainer => _gunContainer;
    public CharacterContainer CharacterContainer => _characterContainer;
    public List<EnemyCharacter> EnemyCharacters => _enemyCharacters;
    public EnemyCharacterContainer EnemyCharacterContainer => _enemyCharacterContainer;
}

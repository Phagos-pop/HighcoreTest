using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyCharacterController
{
    private AllServices _allServices;

    private List<EnemyCharacter> _enemyCharacters;
    private List<float> _enemyCharactersHP;
    private List<Weapon> _weapons;

    public void Init()
    {
        _allServices = AllServices.Container;

        GetCharacters();
    }

    private void GetCharacters()
    {
        _enemyCharacters = _allServices.EnemyCharacters;
        _weapons = _allServices.Weapons;
        var mainCharacter = _allServices.MainCharacter;

        foreach (var item in _enemyCharacters)
        {
            var weapon = _weapons[Random.Range(0, _weapons.Count - 1)];
            weapon = Object.Instantiate(weapon, item.transform);
            weapon.transform.SetPositionAndRotation(item.GunTranform.position, item.GunTranform.rotation);
            var feature = _allServices.GunContainer.gunFeatures.FirstOrDefault(p => p.Type == weapon.Type);
            weapon.Init(feature);
            weapon.gameObject.SetActive(true);
            item.OnApplyDamage += CharacterOnApplyDamage;
            item.Init(weapon, mainCharacter, _allServices.EnemyCharacterContainer.shootDelay);
        }

        _enemyCharactersHP = new List<float>(_enemyCharacters.Count);
        var hp = _allServices.EnemyCharacterContainer.healthPoint;
        for (int i = 0; i < _enemyCharacters.Count; i++)
        {
            _enemyCharactersHP.Add(hp);
        }
    }

    private void CharacterOnApplyDamage(EnemyCharacter character, float value)
    {
        var index = _enemyCharacters.IndexOf(character);
        _enemyCharactersHP[index] -= value;


        if (_enemyCharactersHP[index] < 0)
        {
            var hpValue = _enemyCharactersHP[index];
            character.Destroy();
            _enemyCharacters.Remove(character);
            _enemyCharactersHP.Remove(hpValue);
        }      
    }
}

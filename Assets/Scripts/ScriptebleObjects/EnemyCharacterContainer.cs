using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyCharacterContainer", menuName = "ScriptableObjects/EnemyCharacterContainer", order = 3)]
public class EnemyCharacterContainer : ScriptableObject
{
    public float healthPoint;
    public float shootDelay;
}

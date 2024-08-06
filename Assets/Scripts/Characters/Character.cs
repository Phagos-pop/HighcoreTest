using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamageableCharacter
{
    public abstract void ApplyDamage(float value);
}

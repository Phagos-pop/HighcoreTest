using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GunFeatureContainer", order = 1)]
public class GunFeatureContainer : ScriptableObject
{
    public List<GunFeatureContainerItem> gunFeatures;
}

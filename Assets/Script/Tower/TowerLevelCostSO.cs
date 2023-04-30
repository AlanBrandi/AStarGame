using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New_TurretCost", menuName = "New_TurretCost")]

public class TowerLevelCostSO : ScriptableObject
{
    [Header("Cost")]
    public int gold;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level_0", menuName = "New_TurretLevelupStats")]
public class TowerLevelUpgradeSO : ScriptableObject
{
    [Header("Level Up Stats")]

    public float increaseRange;
    public float increaseBulletSpeed;
    public float increaseExplosionRange;
    public float increaseExplosionForce;
    public float increaseFireRate;
    public float increaseBulletDamage;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerValues", menuName = "Create tower configuration")]
public class TowerValuesSO : ScriptableObject
{
    [Header("Upgrade Configs")]
    public int upgradeLevel = 0;
    public int maxLevel = 3;

    [Header("Bullet Configs")]
    public float range;
    public float bulletSpeed;
    public float explosionRange;
    public float explosionForce;
    public float fireRate;
    public float bulletDamage;

    [Header("BuildCost")]
    public int valueCost;

    [Header("Levels")]
    public GameObject[] buildMesh;
    public TowerLevelCostSO[] levelCost;
    public TowerLevelUpgradeSO[] levels;
}
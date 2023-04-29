using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{


    [Header("Values")]
    [SerializeField]
    public TowerValuesSO towerValues;

    [Header("EnemyDetector")]
    private Collider[] enemyArray;
    private Collider nearestEnemy;

    [Header("Bullet Configs")]
    [SerializeField] 
    private GameObject bullet;

    [SerializeField]
    private Transform bulletTransformSpawn;

    [Header("Upgrade")]
    [SerializeField]
    private GameObject currentPrefab;

    [SerializeField] 
    private LayerMask mask;

    private float cooldownTimer;

    private GameObject CurrentbuildMesh;

    private void Awake()
    {
        TowerValuesSO tempTurretValues = Instantiate(towerValues);
        towerValues = tempTurretValues;
    }
 
    private void FixedUpdate()
    {
        DetectEnemy(towerValues.range);
        Shoot(towerValues.bulletSpeed);
    }
    public float getRange()
    {
        return towerValues.range;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position, towerValues.range);
    }
    public void DetectEnemy(float range)
    {
        enemyArray = Physics.OverlapSphere(transform.position, range, mask);

        foreach (Collider enemy in enemyArray)
        {
            nearestEnemy = enemy;
        }
    }
    public void Shoot(float bulletSpeed)
    {
        if (enemyArray.Length > 0)
        {
            if (cooldownTimer <= Time.time)
            {
                cooldownTimer = Time.time + towerValues.fireRate;

                GameObject tempBullet = Instantiate(bullet, bulletTransformSpawn.position, Quaternion.identity);

                TowerBullet bullet_behaviour = tempBullet.GetComponent<TowerBullet>();
                bullet_behaviour.BulletValues(towerValues.explosionRange, towerValues.explosionForce);

                Rigidbody bullet_rb = tempBullet.GetComponent<Rigidbody>();
                bullet_rb.AddForce((nearestEnemy.gameObject.transform.position - transform.position).normalized * bulletSpeed * 10, ForceMode.Force);

                var dir = nearestEnemy.gameObject.transform.position - tempBullet.transform.position;
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                tempBullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                Destroy(tempBullet, 4);
            }
        }
    }
    public void IncreaseTurretValues(int level)
    {
        if (VerifyResourcesForUpgrade(level))
        {
            towerValues.range += towerValues.levels[level].increaseRange;
            towerValues.bulletSpeed += towerValues.levels[level].increaseBulletSpeed;
            towerValues.explosionRange += towerValues.levels[level].increaseExplosionRange;
            towerValues.explosionForce += towerValues.levels[level].increaseExplosionForce;
            towerValues.fireRate += towerValues.levels[level].increaseFireRate;
            CurrentbuildMesh = towerValues.buildMesh[towerValues.upgradeLevel];
        }
        else
        {
            print("Not Enough resources to upgrade");
            return;
        }

    }
    public bool VerifyResourcesForUpgrade(int level)
    {
        return true;

        /* inv check for money
        if (inventory.gold > turretValues.levelCost[level].gold &&
           inventory.metal > turretValues.levelCost[level].metal &&
           inventory.junk > turretValues.levelCost[level].junk)
        {
            inventory.gold -= turretValues.levelCost[level].gold;
            inventory.metal -= turretValues.levelCost[level].metal;
            inventory.junk -= turretValues.levelCost[level].junk;

            turretValues.upgradeLevel++;

            return true;
        }
        else
        {
            return false;
        }
        */
    }
}

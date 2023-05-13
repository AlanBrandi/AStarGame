using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject playerGO;
    [SerializeField] private Transform whereToSpawn;

    public void SpawnEnemyToPlace()
    {
        Instantiate(playerGO, new Vector3(whereToSpawn.position.x, whereToSpawn.position.y, whereToSpawn.position.z), Quaternion.identity);
    }
}

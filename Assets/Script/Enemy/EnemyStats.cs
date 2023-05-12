using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy")]
public class EnemyStats : ScriptableObject
{
    public string eName;
    public int health;
    public float speed;
}

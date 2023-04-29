using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    [SerializeField] 
    private Collider[] enemyArray;

    [SerializeField] 
    private LayerMask mask;

    [SerializeField] 
    private float explosionRange;

    [SerializeField] 
    private float explosionForce;

    private void OnTriggerEnter(Collider other)
    {
        if (explosionRange > 0)
        {
            ExplosiveBullet(explosionRange);
        }
        Destroy(this.gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
    public void BulletValues(float explosion_range, float explosion_force)
    {
        explosionRange = explosion_range;
        explosionForce = explosion_force;
    }
    public void ExplosiveBullet(float range)
    {
        enemyArray = Physics.OverlapSphere(transform.position, range, mask);
        foreach (Collider enemy in enemyArray)
        {
            /* Dar dano no inimigo.
            if (enemy.TryGetComponent<Health>(out Health entity))
            {
                entity.HealthValue--;
            }
            */
            //knockback
            //enemy.GetComponent<Rigidbody>().AddForce((enemy.gameObject.transform.position - transform.position).normalized * explosionForce, ForceMode.Impulse);
        }
    }


}

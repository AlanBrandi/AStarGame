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

    private bool _followTarget;
    private Collider _target;
    private Rigidbody _rb;
    private float _speed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_followTarget)
        {
            _rb.velocity = (_target.gameObject.transform.position - this.transform.position).normalized * _speed * 20;
        }
    }

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
    public void IsFollowTarget (bool isfollowTarget, Collider target, float speed)
    {
        _followTarget = isfollowTarget;
        _target = target;
        _speed = speed;
    }
}

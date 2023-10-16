using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float towerRange = 15f;
    [SerializeField] ParticleSystem particleSystem;
    Transform target;

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        if (enemies != null)
        {
            float minDistance = Mathf.Infinity;
            Transform closestEnemy = null;

            for (int i = 0; i < enemies.Length; i++)
            {
                float targetDistance = Vector3.Distance(transform.position, enemies[i].transform.position);
                if (targetDistance < minDistance)
                {
                    minDistance = targetDistance;
                    closestEnemy = enemies[i].transform;
                }
            }

            target = closestEnemy;
        }
        
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        if (targetDistance < towerRange)
            weapon.transform.LookAt(target);
    } 

    void Attack(bool isActive)
    {

    }
}

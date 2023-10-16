using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
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
        weapon.transform.LookAt(target);
    } 
}

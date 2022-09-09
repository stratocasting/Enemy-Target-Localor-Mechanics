using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Transform target;
    void Update()
    {
        //line placement is fairly important here
        FindClosestTarget();
        AimWeapon();
    }
    void AimWeapon()
    {
        //this unity method locking tower's face to enemies to 360 degrees also mathf.clamb could be useful for several degrees
        transform.LookAt(target);
    }
    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        //mathf infinity is a high number is just enough for our max distnace
        float maxDistance = Mathf.Infinity;
        foreach(Enemy enemy in enemies)
        {
            //targetDistance Enemy grubundaki ilk [0] üyesinin uzaklığını alarak başlıyor tüm grup üyeleri bitene kadar loop devam ediyor 
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget= enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }
}

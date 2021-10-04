using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Bullet bulletPrefab;
    public float timeBetweenShots = 0.1f;
    protected float timeOfNextShot = 0;

    public Transform muzzlePoint;


    public virtual bool Fire(Vector3 aimPoint)
    {
        if(Time.time > timeOfNextShot)
        {
            timeOfNextShot = Time.time + timeBetweenShots;
            Bullet copy = Instantiate(bulletPrefab, muzzlePoint.position, transform.rotation);
            return true;
        }
        return false;
    }
}

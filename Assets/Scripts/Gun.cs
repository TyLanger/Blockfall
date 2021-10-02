using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Bullet bulletPrefab;
    public float timeBetweenShots = 0.1f;
    float timeOfNextShot = 0;

    public Transform muzzlePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        if(Time.time > timeOfNextShot)
        {
            timeOfNextShot = Time.time + timeBetweenShots;
            Bullet copy = Instantiate(bulletPrefab, muzzlePoint.position, transform.rotation);
        }
    }
}

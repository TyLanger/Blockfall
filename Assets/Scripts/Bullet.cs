using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float moveSpeed = 10;
    int damage = 1;

    float lifetime = 10;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Cleanup", lifetime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, moveSpeed * Time.fixedDeltaTime);
    }

    public void Setup(float speed)
    {
        moveSpeed = speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        // deal damage to other
    }

    private void Cleanup()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public event System.Action<Bullet> OnDestroyed;

    public float _moveSpeed = 10;
    int _damage = 1;

    float lifetime = 10;
    float currentLife = 0;

    bool isPlayerBullet = true;

    // Start is called before the first frame update
    void Start()
    {
        ResetLife();
    }

    private void Update()
    {
        if(currentLife < 0)
        {
            TimeOut();
        }
        currentLife -= Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, _moveSpeed * Time.fixedDeltaTime);
    }

    public virtual void Setup(float speed, int damage)
    {
        _moveSpeed = speed;
        _damage = damage;
    }

    public void ResetLife()
    {
        currentLife = lifetime;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (isPlayerBullet && (other.GetComponent<Player>() != null))
            return;

        // deal damage to other
        Health health = other.GetComponent<Health>();
        if(health)
        {
            health.TakeDamage(_damage);
        }
        // get destroyed when you hit something
        Cleanup();
    }

    protected virtual void TimeOut()
    {
        Cleanup();
    }

    protected void Cleanup()
    {
        OnDestroyed?.Invoke(this);
        Destroy(gameObject);
    }
}

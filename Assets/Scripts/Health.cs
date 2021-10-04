using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public event Action OnDeath;

    [SerializeField]
    int currentHealth;

    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject} is dead");
        OnDeath?.Invoke();
    }
}

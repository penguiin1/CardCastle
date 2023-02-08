using System;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    public float startingHealth = 100f;
    public float health { get; protected set; }
    public bool dead { get; protected set; }
    public event Action onDeath;

    protected virtual void OnEnable()
    {
        dead = false;
        health = startingHealth;
    }
    public virtual void OnDamage(float damage)
    {
        health -= damage;
        
        if(health <= 0 && !dead)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        if(onDeath != null)
        {
            onDeath();
        }
        dead = true;
    }
}

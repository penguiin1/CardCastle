using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Monster : LivingEntity
{
    private LivingEntity targetEntity;
    public float damage = 20f;

    private bool hasTarget
    {
        get
        {
            if(targetEntity != null && !targetEntity.dead)
            {
                return true;
            }
            return false;
        }
    }

    private void Awake()
    {
        
    }

    public void Setup(MonsterData monsterData)
    {

    }

    public override void Die()
    {
        base.Die();
    }

    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
    }
}

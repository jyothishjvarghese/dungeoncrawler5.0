using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public GameObject acidEffectPrefab;
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public override void Update()
    {
        
    }
    public void Damage()
    {
        Health--;
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
        }

    }
    //stops the spider from following the movement code
    public override void Movement()
    {
       
    }

    public void Attack()
    {
        //instantiate the acid effect
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }
}

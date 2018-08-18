using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set;}

    public override void Init()
    {
        base.Init();
        //assign the health functionality
        Health = base.health;
    }

    public void Damage()
    {
        Debug.Log("Damage!");
        //subtract 1 from health
        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        //if health is les than 1 
        //destroy the object
        if(Health < 1)
        {
            Destroy(gameObject);
        }
    }
}

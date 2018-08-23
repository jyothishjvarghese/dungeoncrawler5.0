using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    //instantiate the variables
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    //specific code for moss giant on what damage does to him
    public void Damage()
    {
        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        if(Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
        }
    }
    
}

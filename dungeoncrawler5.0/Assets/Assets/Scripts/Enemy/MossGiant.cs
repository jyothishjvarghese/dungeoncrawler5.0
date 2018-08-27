using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
<<<<<<< HEAD
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
        if (isDead == true)
            return;
        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        if(Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<diamond>().gems = base.gems;
        }

=======
    public override void Init()
    {
        base.Init();
>>>>>>> parent of bf1ed15... Version11.27
    }
    
}

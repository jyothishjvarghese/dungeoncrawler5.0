﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
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
        if (isDead == true)
            return;

        Health--;
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<diamond>().gems = base.gems;
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
=======
public class Spider : Enemy
{ 
    
>>>>>>> parent of bf1ed15... Version11.27
}

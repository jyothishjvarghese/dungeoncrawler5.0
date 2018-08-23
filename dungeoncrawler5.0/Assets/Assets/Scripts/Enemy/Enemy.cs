using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;

    protected bool _switch; 
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected bool isHit = false;
    //get variable to enemy
    protected Player playerUnit;
    private float distanceBetweenPlayerEnemy;
    protected bool isDead = false;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        playerUnit = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }
    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        //This is to pause the object at its different waypoints
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false)
        {
            return;
        }

        //if Dead, then stop moving
        if (isDead == false)
        {
            Movement();
        }
    }

    public virtual void Movement()
    {
        //if at pointA, stop moving, play the idle animation, flip the sprite
        if (transform.position == pointA.position)
        {
            _switch = false;
            anim.SetTrigger("Idle");
            sprite.flipX = false;
                              
        }
        else if (transform.position == pointB.position)
        {
            _switch = true;
            anim.SetTrigger("Idle");
            sprite.flipX = true;
                      
        }
        //if not in combat, then move betwen point a and point b
        if (isHit == false)
        {
            if (_switch == false)
                transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            else if (_switch == true)
                transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
        }
        
        //check for distance between player and enemy to check whether if it is in combat or not
        distanceBetweenPlayerEnemy = Vector3.Distance(transform.localPosition, playerUnit.transform.localPosition);
        if(distanceBetweenPlayerEnemy > 2.0f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
        //this makes the enemy face the player during combat
        Vector3 direction = playerUnit.transform.position - transform.position;
        if(direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = false;
        }
        else if(direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = true;
        }
    }






}
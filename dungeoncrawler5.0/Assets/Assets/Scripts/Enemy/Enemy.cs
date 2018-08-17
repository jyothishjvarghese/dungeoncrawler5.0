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
  

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

    }
    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        Movement();
    }

    public virtual void Movement()
    {

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

        if (_switch == false)
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
        else if(_switch == true)
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);


    }






}
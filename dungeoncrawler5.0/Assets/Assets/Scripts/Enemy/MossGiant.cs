using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    
    private SpriteRenderer _mossGiantEnemy;
    private Animator _mossGiantAnimator;
    private bool _switch;

    public void Start(){
        _mossGiantEnemy = GetComponentInChildren<SpriteRenderer>();
        _mossGiantAnimator = GetComponentInChildren<Animator>();
    }
    public override void Update() {

        //if idle animation
        //return
        if(_mossGiantAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        Movement();
        
    }
    void Movement()
    {
        Debug.Log("Transform.position = " + transform.position);
        if (transform.position == pointA.position)
        {
            _mossGiantAnimator.SetTrigger("Idle");
            _switch = false;
            _mossGiantEnemy.flipX = false;

        }
        else if (transform.position == pointB.position)
        {
            _mossGiantAnimator.SetTrigger("Idle");
            _switch = true;
            _mossGiantEnemy.flipX = true;

        }

        if (_switch == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
        }
        if (_switch == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
        }
        
    }
    

}

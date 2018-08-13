using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    private Animator _spiderAnim;
    private SpriteRenderer _spiderSprite;
    private bool _switch;

	// Use this for initialization
	void Start () 
    {
        _spiderAnim = GetComponentInChildren<Animator>();
        _spiderSprite = GetComponentInChildren<SpriteRenderer>();
		
	}
	
	// Update is called once per frame
	public override void Update ()
    {
        if(_spiderAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        Movement();
		
	}
    public void Movement()
    {
        //Debug.Log("Transform.position = " + transform.position);
        if (transform.position == pointA.position)
        {
            _spiderAnim.SetTrigger("Idle");
            _switch = false;
            _spiderSprite.flipX = false;

        }
        else if (transform.position == pointB.position)
        {
            _spiderAnim.SetTrigger("Idle");
            _switch = true;
            _spiderSprite.flipX = true;

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

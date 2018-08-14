using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy {

    private bool _switch;
    private Animator _skeletonAnim;
    private SpriteRenderer _skeletonSprite;

	// Use this for initialization
	void Start ()
    {
        _skeletonAnim = GetComponentInChildren<Animator>();
        _skeletonSprite = GetComponentInChildren<SpriteRenderer>();
		
	}
	
	// Update is called once per frame
	public override void Update ()
    {
        if (_skeletonAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        Movement();
    }
    void Movement()
    {
        if(transform.position == pointA.position)
        {
            _switch = false;
            _skeletonAnim.SetTrigger("Idle");
            _skeletonSprite.flipX = false;
            
        }
        else if(transform.position == pointB.position)
        {
            _switch = true;
            _skeletonAnim.SetTrigger("Idle");
            _skeletonSprite.flipX = true;
        }

        if(_switch == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
        }
        if(_switch == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
        }
    }
}

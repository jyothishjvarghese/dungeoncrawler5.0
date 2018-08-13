using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _currentTarget;
    private SpriteRenderer _mossGiantEnemy;
    private bool _switch;

    public void Start(){
        _mossGiantEnemy = GetComponent<SpriteRenderer>();
    }
    public override void Update() {

        Movement();
        
    }
    void Movement()
    {
        if (transform.position == pointA.position)
        {

            //_switch = false;
            Debug.Log("Current target: " + _currentTarget);
            _currentTarget = pointB.position;
            

        }
        else if (transform.position == pointB.position)
        {
            //_switch = true;
            Debug.Log("Current target: " + _currentTarget);
            _currentTarget = pointA.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
       

        //if(_switch == false)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
        //}
        //if(_switch == true)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
        //}
    }
    
}

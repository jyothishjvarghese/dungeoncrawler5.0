using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    //handle to the spider
    protected Spider spiderUnit;

    private void Start()
    {
        //assign handle to spider
        spiderUnit = transform.parent.GetComponent<Spider>();
    }
    public void Fire()
    {
        //Tell spider to fire
        Debug.Log("Spider should fire!");
        //use handle to call Attack method on spider
        spiderUnit.Attack();
    }
	
}

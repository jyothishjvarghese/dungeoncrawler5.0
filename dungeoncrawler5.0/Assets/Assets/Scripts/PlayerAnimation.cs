using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //handle to animator 
    private Animator _anim;
    private SpriteRenderer _sprite;
    void Start()
    {
        //assign handle 
        _anim = GetComponentInChildren<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }
    public void Run(float move)
    {

        _anim.SetFloat("Move", Mathf.Abs(move));
        if (move < 0)
            _sprite.flipX = true;
        else if (move > 0)
            _sprite.flipX = false;

    }
    public void Jump()
    {
        _anim.SetTrigger("Jump");
    }

}

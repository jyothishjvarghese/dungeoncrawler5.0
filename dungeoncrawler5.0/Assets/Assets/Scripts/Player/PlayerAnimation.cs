using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //handle to animator 
    private Animator _anim;
    private SpriteRenderer _sprite;
    private SpriteRenderer _swordSprite;

    //reference to sword
    private Animator _swordAnimation;

    void Start()
    {
        //assign handle 
        _anim = GetComponentInChildren<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _swordAnimation = transform.GetChild(1).GetComponent<Animator>();
        _swordSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }
    //player run animation code
    public void Run(float move)
    {

        _anim.SetFloat("Move", Mathf.Abs(move));
        if (move < 0)
            Flip(false);
        else if (move > 0)
            Flip(true);

    }
    //player jump animation code
    public void Jump()
    {
        _anim.SetTrigger("Jump");
    }
    //flip if needed
    public void Flip(bool faceRight)
    {
        if(faceRight == true)
        {
            _sprite.flipX = false;
            _swordSprite.flipX = false;
            _swordSprite.flipY = false;

            //move the sprite by 1.01f 
            Vector3 newPos = _swordSprite.transform.localPosition;
            newPos.x = 1.01f;
            _swordSprite.transform.localPosition = newPos;
        }
        else if(faceRight == false)
        {
            _sprite.flipX = true;
            _swordSprite.flipX = true;
            _swordSprite.flipY = true;

            Vector3 newPos = _swordSprite.transform.localPosition;
            newPos.x = 1.01f;
            _swordSprite.transform.localPosition = newPos;
        }

    }
    //call attack animation
    public void Attack()
    {
        _anim.SetTrigger("Attack");
        //play sword animation
        _swordAnimation.SetTrigger("SwordAnimation");
    }

}

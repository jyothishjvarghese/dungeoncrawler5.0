using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    protected float _jumpForce = 5.0f;
    [SerializeField]
    protected float _speed = 3.0f;
    [SerializeField]
    private bool isGrounded = false;
    [SerializeField]
    private LayerMask groundLayer;
    private bool resetJumpNeeded;
    //get handle for rigidbody2d
    protected Rigidbody2D _rigid;
    private PlayerAnimation _player;
    

	// Use this for initialization
	void Start ()
    {

        //assign handle for rigidbody
        _rigid = GetComponent<Rigidbody2D>();
        _player = GetComponent<PlayerAnimation>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
        if(Input.GetMouseButtonDown(0) && isGrounded == true)
        {
            _player.Attack();
        }
    }

    public void Movement()
    {
        
        float transition = Input.GetAxis("Horizontal");
        
              
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            
            _rigid.velocity = new Vector2(transition, _jumpForce);
            _player.Jump();
            isGrounded = false;
            resetJumpNeeded = true;
            StartCoroutine(ResetJumpRoutine());
        }

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.green);

        if (hitInfo.collider != null)
        {
            //Debug.Log("Hitting: " + hitInfo.collider.name);

            if (resetJumpNeeded == false)
            {
                isGrounded = true;
            }
        }
        else
            isGrounded = false;

         _rigid.velocity = new Vector2(transition * _speed, _rigid.velocity.y);
        _player.Run(transition);
        
    }
    IEnumerator ResetJumpRoutine()
        {
            yield return new WaitForSeconds(0.1f);
            resetJumpNeeded = false;
        }
}

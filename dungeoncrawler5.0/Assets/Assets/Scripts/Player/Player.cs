using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable {


    public int diamonds;

    [SerializeField]
    protected float _jumpForce = 5.0f;
    [SerializeField]
    protected float _speed = 3.0f;
    [SerializeField]
    private bool isGrounded = false;
    [SerializeField]
    private LayerMask groundLayer;
    private bool resetJumpNeeded;
    protected Rigidbody2D _rigid;
    private PlayerAnimation _player;
    
    public int Health { get; set; }
    
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
        //this code starts the attack module
        if(Input.GetKeyDown(KeyCode.L) && isGrounded == true)
        {
            _player.Attack();
        }
    }

    public void Movement()
    {
        //a left s right
        float transition = Input.GetAxis("Horizontal");
        
        //jump      
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            
            _rigid.velocity = new Vector2(transition, _jumpForce);
            _player.Jump();
            isGrounded = false;
            resetJumpNeeded = true;
            StartCoroutine(ResetJumpRoutine());
        }

        //check whether u can jump or not
        //draw a line that hits the ground
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

        //run with a specific speed without jump
         _rigid.velocity = new Vector2(transition * _speed, _rigid.velocity.y);
        _player.Run(transition);
        
    }
    IEnumerator ResetJumpRoutine()
        {
            yield return new WaitForSeconds(0.1f);
            resetJumpNeeded = false;
        }
    public void Damage()
    {
        Debug.Log("Player::Damage");
    }
}

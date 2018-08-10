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
    //get handle for rigidbody2d
    protected Rigidbody2D _rigid;
    

	// Use this for initialization
	void Start ()
    {

        //assign handle for rigidbody
        _rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
    }

    public void Movement()
    {
        //horizontal input for left and right
        //current velocity = new velocity (x, velocity.y)
        float transition = Input.GetAxis("Horizontal");
        _rigid.velocity = new Vector2(transition * _speed, _rigid.velocity.y);

        //check for isGrounded
        //check for Input.GetkeyDOwn.keycode.space
        //current velocity = new vector2(transition, jumpforce)

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.green);
        if (hitInfo.collider != null)
        {
            Debug.Log("Hitting: " + hitInfo.collider.name);
            isGrounded = false;
        }
        else
            isGrounded = true;
        

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == false)
        {
            Debug.Log("Jump!");
            _rigid.velocity = new Vector2(transition, _jumpForce);
            isGrounded = false;
        }
        //2d raycast to the ground
        //if hitInfo != null
        //isGrounded = true;
        
        

    }
}

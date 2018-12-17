using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    //Variablen
    public float movementSpeed = 40f;
    public float maxSpeed = 3.5f;
    public float currentSpeed;
    //private bool facingRight = true;
    private Rigidbody2D rb2d;
    private Animator anim;
    [SerializeField] Camera playerCamera;


    void Start ()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        anim.SetFloat("speed", rb2d.velocity.x);
        
    }
	
	
	void FixedUpdate ()
    {

        float move = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);

        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;
       
       
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
     
     }


    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(rb2d.velocity.x));

        float currentSpeed = rb2d.velocity.x;
        if (rb2d.velocity.x < 0.1f)
        {
            currentSpeed = 0;
            anim.SetFloat("speed", currentSpeed);
        }

    
         


        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }


    }
}

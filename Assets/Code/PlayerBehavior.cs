using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float UserSpeed = 8;
    public float SlideSpeed = 20;

    private float direction = 0f;

    public Vector2 jumpMag = new Vector2(0, 900);


    private Rigidbody2D rb2D;


    
    //turning the player's facing direction

    bool DBLJump = true;
    bool JumpTimeout = false;
   


    void Start()
    {
        
        rb2D = GetComponent<Rigidbody2D>();
       
    }

    private void Update()
    {
        //Normal Movement
        direction = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.right * UserSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.left * UserSpeed * Time.deltaTime);
            if (direction < 0f)
                
            {
                transform.localScale = new Vector2(-1f, 1f);
            }
           
        }




        //With sliding movement
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.right * SlideSpeed * Time.deltaTime);
            GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 0.75f);
            GetComponent<Transform>().localScale = new Vector2(1.5f, 0.75f);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.left * SlideSpeed * Time.deltaTime);
            GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 0.75f);
            GetComponent<Transform>().localScale = new Vector2(-1.5f, 0.75f);
        }


        //Resets slide stretching
        if (!Input.GetKey(KeyCode.S))
        {
            GetComponent<BoxCollider2D>().size = new Vector2(1.0f, 1.0f);
            GetComponent<Transform>().localScale = new Vector2(1.0f, 1.0f);
        }


        //DoubleJump
        if (Input.GetKeyDown(KeyCode.W) && !JumpTimeout)
        {
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(jumpMag);

            JumpTimeout = true;
        }

        else if (DBLJump == true && Input.GetKeyDown(KeyCode.W))
        {
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(jumpMag);
            DBLJump = false;
        }

    }
    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            print("testhit");
            JumpTimeout = false;
            DBLJump = true;
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FastballBehavior : MonoBehaviour
{

    public GameObject PlayerPos;
    private Rigidbody2D rb;
    

    private Vector2 incomingVelocity;
    public float Timer;
    

    public bool Shield = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        PlayerPos = GameObject.Find("Player");
      
        Vector3 difAngle = (PlayerPos.transform.position - transform.position);
        //Finds difference from players transform and balls transform after ball is spawned

        rb.AddForce(difAngle * 60f);
        //Add force takes destination/endpoint and a magnitude.

        Timer = .85f;


        Destroy(gameObject, 2f);
        //Destorys object after 2 seconds.
    }

    // Update is called once per frame
    void Update()
    {
        incomingVelocity = rb.velocity;

        Timer = Timer - Time.deltaTime;
        if (Timer <= 0)
        {
            rb.gravityScale = 1.25f;
        }
        //Creates a more realistic gravity effect on ball
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.tag == "Borders" || collision.gameObject.tag == "Bat")
        {
            var speed = incomingVelocity.magnitude;
            var direction = Vector2.Reflect(incomingVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * speed * 1.75f;
            //This needs a LOT of work, in order to make hitting the ball at an enemy feasible.
        }

        else if (collision.gameObject.tag == "Player")
        {
            GCBehavior gCBehavior = FindObjectOfType<GCBehavior>();
            gCBehavior.UpdateLives();
            Destroy(gameObject);
            
        }

        else if (collision.gameObject.tag == "Enemy")
        {
            GCBehavior gCBehavior = FindObjectOfType<GCBehavior>();
            gCBehavior.UpdateScoreEnemy();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        

    } 

}

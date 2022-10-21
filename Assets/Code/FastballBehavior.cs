using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FastballBehavior : MonoBehaviour
{

    public GameObject playerPos;
    private Rigidbody2D rb;
    

    private Transform player;
    private Vector2 incomingVelocity;
    public float Timer;

    public bool Shield = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        playerPos = GameObject.Find("Player");
      
        Vector3 difAngle = (playerPos.transform.position - transform.position);
        //Finds difference from players transform and balls transform after ball is spawned

        rb.AddForce(difAngle * 100f);
        //Add force takes destination/endpoint and a magnitude.

        Timer = .5f;


        Destroy(gameObject, 5f);
        //Destorys object after 5 seconds.
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
            rb.velocity = direction * speed * 0.75f;
        }
        if (collision.gameObject.tag == "Player") // and !Shield
        {
            //start death anim?
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            GCBehavior gCBehavior = FindObjectOfType<GCBehavior>();
            gCBehavior.UpdateScoreEnemy();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    } 

}

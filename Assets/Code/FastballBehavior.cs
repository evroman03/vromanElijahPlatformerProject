using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FastballBehavior : MonoBehaviour
{
    private GameObject Player;
    public GameObject PlayerPos;
    private Rigidbody2D rb;

    public AudioClip BatSound;

    private Vector2 incomingVelocity;
    public float Timer;
    public bool TouchedGround;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        PlayerPos = GameObject.Find("Player");
        
      
        Vector3 difAngle = (PlayerPos.transform.position - transform.position);
        //Finds difference from players transform and balls transform after ball is spawned
        
        rb.AddForce(difAngle.normalized * 15f, ForceMode2D.Impulse);
        //Add force takes destination/endpoint and a magnitude.

        Timer = 1.25f;


        Destroy(gameObject, 3f);
        //Destorys object after 2 seconds.
    }

    // Update is called once per frame
    void Update()
    {
        incomingVelocity = rb.velocity;

        Timer = Timer - Time.deltaTime;
        if (Timer <= 0)
        {
            rb.gravityScale = 1f;
        }
        //Creates a more realistic gravity effect on ball
       
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Bat")
        {
            TouchedGround = true;
        }
         if ( collision.gameObject.tag == "Bat")
        {
            var speed = incomingVelocity.magnitude;
            //var direction = Vector2.Reflect(incomingVelocity.normalized, collision.contacts[0].normal);
            AudioSource.PlayClipAtPoint(BatSound, Camera.main.transform.position);


            if (PlayerPos.GetComponent<SpriteRenderer>().flipX == false)
            {
                rb.velocity = new Vector2(-1f * speed * 1.25f, Random.Range(4, 11));
                
            }
            else
            {
                rb.velocity = new Vector2(1f * speed * 1.25f, Random.Range(4, 11));
                
            }
                gameObject.layer = LayerMask.NameToLayer("Ball");

        
        }

        if (collision.gameObject.tag == "Player" && !TouchedGround)
        {
            GCBehavior gCBehavior = FindObjectOfType<GCBehavior>();
            gCBehavior.UpdateLives();
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

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



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.Find("Player");
      
        Vector3 difAngle = (playerPos.transform.position - transform.position);
        
        rb.AddForce(difAngle * 100f);

        Timer = .5f;









        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        incomingVelocity = rb.velocity;

        Timer = Timer - Time.deltaTime;
        if (Timer <= 0)
        {
            rb.gravityScale = 1.75f;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.tag == "Borders" || collision.gameObject.tag == "Platform")
        {
            var speed = incomingVelocity.magnitude;
            var direction = Vector2.Reflect(incomingVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * speed * 0.75f;
        } 
    } 

}

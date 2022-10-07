using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float UserSpeed = 8;
    public float Timer;
    public Vector2 jumpMag = new Vector2(0, 1200);

    private Rigidbody2D rb2D;

    bool JumpTimeout = false;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * UserSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * UserSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.W) && !JumpTimeout)
        {
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(jumpMag);
            JumpTimeout = true;
            Timer = .55f;
        }
        if(JumpTimeout == true)
            {
               
                Timer = Timer - Time.deltaTime;
                if (Timer <= 0)
                {
                    JumpTimeout = false;
                }
            }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platforms")
        {
            print("testhit");
        }
    }



}

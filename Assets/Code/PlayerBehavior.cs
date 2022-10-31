using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    public float UserSpeed = 500f;
    public float BoostSpeed = 750f;
    public float NormalSpeed = 500f;
    public float SlideSpeed = 500f;
    public float DrankTimer;

    public GameObject Bat;
    public Vector2 JumpMag = new Vector2(0, 900);

    public float xMove;

    private SpriteRenderer sr;
    private Rigidbody2D rb2D;
    public GCBehavior GCBehavior;

    //public static int Drank;
    //public TMP_Text DrankText;

    bool DBLJump = true;
    bool JumpTimeout = false;
    bool Sliding = false;
    bool BoostActive = false;

    void Start()
    {
        
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

    }
    public void FixedUpdate()
    {
        if (Sliding)
        {
            rb2D.velocity = new Vector2(xMove * SlideSpeed * Time.deltaTime, rb2D.velocity.y);
            transform.localScale = new Vector2(1.5f, 0.75f);
        }
        else
        {
            rb2D.velocity = new Vector2(xMove * UserSpeed * Time.deltaTime, rb2D.velocity.y);
        }
    }
    private void Update()
    {
        xMove = Input.GetAxis("Horizontal");
        if (xMove < 0)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }

        if (DrankTimer > 0)
        {
            UserSpeed = BoostSpeed;
            //SlideSpeed = 20;
            DrankTimer = DrankTimer - Time.deltaTime;
            BoostActive = true;
        }
        if (DrankTimer <= 0 && BoostActive)
        {
            UserSpeed = NormalSpeed;
            //SlideSpeed = 15;
            GCBehavior.Drank -= 1;
            GCBehavior.DrankText.text = "x" + GCBehavior.Drank;
            BoostActive = false;

        }

        //Resets slide stretching
        if (Input.GetKey(KeyCode.S))
        {
            Sliding = true;
        }
        else
        {
            Sliding = false;
            GetComponent<BoxCollider2D>().size = new Vector2(1.0f, 1.0f);
            GetComponent<Transform>().localScale = new Vector2(Mathf.Sign(transform.localScale.x) * 1.0f, 1.0f);
        }
        

        

        //DoubleJump
        if (Input.GetKeyDown(KeyCode.W) && !JumpTimeout)
        {
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(JumpMag);
            JumpTimeout = true;
        }
        else if (DBLJump == true && Input.GetKeyDown(KeyCode.W))
        {
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(JumpMag);
            DBLJump = false;
        }



        if ((Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.Mouse0))) && !Sliding)
        {   
            Bat.SetActive(true);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bonus")
        {
            GCBehavior gCBehavior = FindObjectOfType<GCBehavior>();
            gCBehavior.UpdateScoreBonus();
            Destroy(collision.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            JumpTimeout = false;
            DBLJump = true;
        }
        
        if (collision.gameObject.tag == "Shield")
        {
            GCBehavior gCBehavior = FindObjectOfType<GCBehavior>();
            gCBehavior.UpdateShield();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Drank")
        {
            GCBehavior gCBehavior = FindObjectOfType<GCBehavior>();
            gCBehavior.UpdateDrank();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            GCBehavior.UpdateLives();
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Drank")
        {
            DrankTimer = 3f;
            Destroy(collision.gameObject);
        }
    }
}

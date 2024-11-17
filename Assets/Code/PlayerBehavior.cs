using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    public float UserSpeed = 450f;
    public float BoostSpeed = 800f;
    public float NormalSpeed = 450f;
    public float SlideSpeed = 600f;
    public float DrankTimer;
    public Animator myAnimator;
    public GameObject Bat;
    public Vector2 JumpMag = new Vector2(0, 900);

    public float xMove;

    private SpriteRenderer sr;
    private Rigidbody2D rb2D;
    public GCBehavior GC;

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
            //transform.localScale = new Vector2(1.5f, 0.75f);
            GetComponent<BoxCollider2D>().size = new Vector2(1.25f, 0.5f);
            myAnimator.SetBool("Slide", true);
        }
        else 
        {
            rb2D.velocity = new Vector2(xMove * UserSpeed * Time.deltaTime, rb2D.velocity.y);
            
        }

        if (rb2D.velocity == Vector2.zero || Sliding == false)
        {
            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Slide", false);
        }
        if (rb2D.velocity.x != 0f)
        {
            myAnimator.SetBool("Walk", true);
        }
       
    }
    private void Update()
    {
        xMove = Input.GetAxis("Horizontal");
        if (xMove < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
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
            //GC.DrankText.text = "x" + GCBehavior.Drank;
            BoostActive = false;

        }

        //Resets slide stretching
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sliding = true;
        }
        else
        {
            Sliding = false;
            GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 2.75f);
            //GetComponent<Transform>().localScale = new Vector2(Mathf.Sign(transform.localScale.x) * 1.0f, 1.0f);
        }
        

        

        //DoubleJump
        if (Input.GetKeyDown(KeyCode.Space) && !JumpTimeout)
        {
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(JumpMag);
            JumpTimeout = true;
            myAnimator.SetTrigger("Jump");
        }
        else if (DBLJump == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(JumpMag);
            DBLJump = false;
            myAnimator.SetTrigger("Jump");
        }



        if (((Input.GetKeyDown(KeyCode.Mouse0))) && !Sliding)
        {
            BatBehavior temp = Bat.GetComponent<BatBehavior>();
            temp.CallSwing();
            myAnimator.SetTrigger("Swing");
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
        if (collision.gameObject.tag == "Shield" && GCBehavior.Shield == 0)
        {
            GCBehavior gCBehavior = FindObjectOfType<GCBehavior>();
            gCBehavior.UpdateShield();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Shield" && GCBehavior.Shield == 1)
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Drank" && GCBehavior.Drank == 0)
        {         
            DrankTimer = 3f;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Drank" && GCBehavior.Drank == 1)
        {
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
        if (collision.gameObject.tag == "Enemy")
        {
            GC.UpdateLives();
            Destroy(collision.gameObject);
        }

    }
}

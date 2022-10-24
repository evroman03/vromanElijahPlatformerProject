using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    public float UserSpeed = 6;
    public float SlideSpeed = 15;
    public float DrankTimer;

    public GameObject Bat;
    public Vector2 jumpMag = new Vector2(0, 900);

    
    private SpriteRenderer sr;
    private SpriteRenderer eyesr;
    private Rigidbody2D rb2D;

    bool DBLJump = true;
    bool JumpTimeout = false;
    bool Sliding = false;

    void Start()
    {
        
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
       
    }

    private void Update()
    {
        //Normal Movement
       

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.right * UserSpeed * Time.deltaTime);
            transform.localScale = new Vector2(1f, 1f);
            sr.flipX = false;
       
        }
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.left * UserSpeed * Time.deltaTime);
            transform.localScale = new Vector2(1f, 1f);
            sr.flipX = true;
        
           
        }

        //With sliding movement
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.right * SlideSpeed * Time.deltaTime);
            GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 0.75f);
            GetComponent<Transform>().localScale = new Vector2(1.5f, 0.75f);
            Sliding = true;
            sr.flipX = false;
          
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.left * SlideSpeed * Time.deltaTime);
            GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 0.75f);
            GetComponent<Transform>().localScale = new Vector2(1.5f, 0.75f);
            Sliding = true;
            sr.flipX = true;
        }
        if (DrankTimer > 0)
        {
            UserSpeed = 10;
            SlideSpeed = 20;
            DrankTimer = DrankTimer - Time.deltaTime;
        }
        if (DrankTimer <= 0)
        {
            UserSpeed = 6;
            SlideSpeed = 15;
            //Drank -= 1f;
            //DrankText.text = "x " + Drank;
        }

        //Resets slide stretching
        if (!Input.GetKey(KeyCode.S))
        {
            GetComponent<BoxCollider2D>().size = new Vector2(1.0f, 1.0f);
            GetComponent<Transform>().localScale = new Vector2(Mathf.Sign(transform.localScale.x) * 1.0f, 1.0f);
            Sliding = false;
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



        if ((Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.Mouse0))) && !Sliding && !GCBehavior.batCooldown)
        {   
            Bat.SetActive(true);
        }
    }
    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            JumpTimeout = false;
            DBLJump = true;
        }
        if (collision.gameObject.tag == "Bonus")
        {
            GCBehavior gCBehavior = FindObjectOfType<GCBehavior>();
            gCBehavior.UpdateScoreBonus();
            Destroy(collision.gameObject);
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
            Destroy(gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        if (collision.gameObject.tag == "Drank")
        {
            DrankTimer = 3f;
            Destroy(collision.gameObject);
        }
    }
}

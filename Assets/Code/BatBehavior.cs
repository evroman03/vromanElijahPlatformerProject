using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBehavior : MonoBehaviour
{
    private float BatSwingTimer;
    public GameObject Player;
    private Vector2 Offset = new Vector2 (0.5f, 0.25f);
    private SpriteRenderer sr;
    private BoxCollider2D bc;


    // Start is called before the first frame update
    void Start()
    {
        BatSwingTimer = .75f;
        GCBehavior.batCooldown = true;
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        BatSwingTimer = BatSwingTimer - Time.deltaTime;
        if (BatSwingTimer <= 0f)
        {
            BatSwingTimer = .75f;
            gameObject.SetActive(false);
            GCBehavior.batCooldown = false;

        }
        gameObject.transform.position = new Vector3(Player.transform.position.x + Offset.x,
            Player.transform.position.y + Offset.y, gameObject.transform.position.z);
        if (Player.GetComponent<SpriteRenderer>().flipX == true)
        {
            Offset.x = -.5f;
            sr.flipX = true;
            bc.offset = new Vector2(-0.3f, 0.025f);
        }
        else
        {
            Offset.x = .5f;
            sr.flipX = false;
            bc.offset = new Vector2(0.3f, 0.025f);
        }
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GCBehavior gCBehavior = FindObjectOfType<GCBehavior>();
            gCBehavior.UpdateScoreEnemy();
            Destroy(collision.gameObject);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBehavior : MonoBehaviour
{
    private float batSwingTimer;
    public GameObject Player;
    private Vector2 offset = new Vector2 (0.5f, 0.25f);
    private SpriteRenderer sr;
    private BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        batSwingTimer = .55f;
        GCBehavior.BatCooldown = true;
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        batSwingTimer = batSwingTimer - Time.deltaTime;
        if (batSwingTimer <= 0f)
        {
            batSwingTimer = .55f;
            gameObject.SetActive(false);
            GCBehavior.BatCooldown = false;
        }

        gameObject.transform.position = new Vector3(Player.transform.position.x + offset.x,
            Player.transform.position.y + offset.y, gameObject.transform.position.z);

        if (Player.GetComponent<SpriteRenderer>().flipX == false)
        {
            offset.x = .5f;
            sr.flipX = false;
            bc.offset = new Vector2(-0.3f, 0.025f);
        }
        else
        {
            offset.x = -.5f;
            sr.flipX = true;
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

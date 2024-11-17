using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBehavior : MonoBehaviour
{
    [SerializeField] private float batSwingTimer;
    public GameObject Player;
    private SpriteRenderer sr;
    private BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        GCBehavior.BatCooldown = true;
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Player.GetComponent<SpriteRenderer>().flipX == false)
        {
            sr.flipX = false;
            bc.offset = new Vector2(0.25f, 0);
        }
        else
        {
            sr.flipX = true;
            bc.offset = new Vector2(-0.75f, 0);
        }
        
    }
    public void CallSwing()
    {
        StartCoroutine(Swing());
    }
    private IEnumerator Swing()
    {
        sr.enabled = true;
        bc.enabled = true;
        var temptime = batSwingTimer;
        while(temptime > 0)
        {
            temptime -= Time.deltaTime;
            yield return null;
        }
        bc.enabled = false;
        sr.enabled= false;
    }
    public void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GCBehavior gCBehavior = FindObjectOfType<GCBehavior>();
            gCBehavior.UpdateScoreEnemy();
            Destroy(collision.gameObject);

        }
    }
}

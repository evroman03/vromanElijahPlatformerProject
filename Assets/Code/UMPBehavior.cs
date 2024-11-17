using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class UMPBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public float PatrolSpeed = 50;
    public int PatrolCount = 0;
    public int PatrolLimit = 45;
    public GCBehavior GCBehavior;
    void Start()
    {
        var GameCont = GameObject.Find("GC");
        GCBehavior = GameCont.GetComponent<GCBehavior>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Patrol();

        PatrolCount++;

        if (PatrolCount >= PatrolLimit)
        {
            Flip();
            PatrolCount = 0;
        }
    }
    void Patrol()
    {
        rb.velocity = new Vector2(PatrolSpeed * Time.deltaTime, rb.velocity.y);
    }
    void Flip()
    {
       
        transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
        PatrolSpeed *= -1f;
    }
}

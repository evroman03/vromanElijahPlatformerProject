using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Rigidbody2D Ball;
    public Transform enemyFront;
    public Rigidbody2D Enemyrb2D;
    public GameObject PlayerPos;
    public Animator enemyAnimator;

    public float enemyRange;
    public float AttackDelay;


    void Start()
    {
        enemyRange = 15;
        AttackDelay = 4f;
        StartCoroutine(ShootTimer());
        
        //will run code if in a loop. yield return tells it to wait for a certain amount of time, and then goes back.
        // TA helped with this Coroutine

    }

    
    void Update()
    {
        PlayerPos = GameObject.Find("Player");
        // if (PlayerPos.transform.position >= transform.position)
        enemyRange = Vector2.Distance(transform.position, PlayerPos.transform.position);
    }
    
    IEnumerator ShootTimer()
    {
        while(true)
        {
            if (enemyRange <= 12)
            {
                Instantiate(Ball, enemyFront.position, Quaternion.identity);
                enemyAnimator.SetTrigger("Pitch");
                yield return new WaitForSecondsRealtime(AttackDelay);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}

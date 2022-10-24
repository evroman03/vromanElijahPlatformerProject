using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Rigidbody2D Ball;
    public Transform enemyFront;
    public Rigidbody2D Enemyrb2D;


    public float AttackdDelay;


    void Start()
    {
        AttackdDelay = 4f;
        StartCoroutine(ShootTimer());
        //will run code if in a loop. yield return tells it to wait for a certain amount of time, and then goes back.
    

    }

    
    void Update()
    {
      
    }
    
    IEnumerator ShootTimer()
    {
       
        while(true)
        {
            Instantiate(Ball, enemyFront.position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(AttackdDelay);
        }
    }
}

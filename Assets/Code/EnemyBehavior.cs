using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Rigidbody2D Ball;
    public Transform enemyFront;
    public Rigidbody2D Enemyrb2D;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(Ball, enemyFront.position, Quaternion.identity);

        }
        //GetComponent<Rigidbody2D>().transform.position.x;
    }
}

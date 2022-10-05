using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float userSpeed = 5;
    public Vector2 jumpMag = new Vector2(0, 150);

    private Rigidbody2D rb2D;




    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * userSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * userSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            
            rb2D.AddForce(jumpMag);
        }
    }




}

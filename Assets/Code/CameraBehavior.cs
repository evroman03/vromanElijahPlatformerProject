using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public GameObject Player;
    public Vector2 Offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Player.transform.position.x + Offset.x,
            gameObject.transform.position.y + Offset.y, gameObject.transform.position.z);
        print("shit");
    }
}
 
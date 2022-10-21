using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBehavior : MonoBehaviour
{
    private float BatSwingTimer;
    public GameObject Bat;
    // Start is called before the first frame update
    void Start()
    {
        BatSwingTimer = .25f;
    }

    // Update is called once per frame
    void Update()
    {
        BatSwingTimer = BatSwingTimer - Time.deltaTime;
        if (BatSwingTimer <= 0f)
        {
            Bat.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBehavior : MonoBehaviour
{
    private float BatSwingTimer;
    // Start is called before the first frame update
    void Start()
    {
        BatSwingTimer = .75f;
        GCBehavior.batCooldown = true;
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
    }
}

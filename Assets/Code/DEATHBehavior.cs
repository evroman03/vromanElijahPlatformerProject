using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEATHBehavior : MonoBehaviour
{
    private float secondsToDestroy = 30f;
    void Start()
    {
        StartCoroutine(DestroySelf());
    }

    // Update is called once per frame
    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(secondsToDestroy);
        Destroy(gameObject);
    }
}

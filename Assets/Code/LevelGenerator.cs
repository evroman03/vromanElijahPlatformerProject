using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{   
    public Transform Level0_1;
    public Transform [] LevelPart;
    public Transform LevelPartEnd;

    public bool HasEndSpawned = false;

    public int chunkCount;


    
    private Vector3 lastEndPosition;

    private const float SpawnDistance = 25f;
    //How far ahead the world will generate
    public GameObject player;


    // Start is called before the first frame update
    private void Awake()
    {
        lastEndPosition = Level0_1.Find("EndPosition").position;
        print("shit");
        SpawnLevelPart();
        //This calls the SpawnLevelPart f(x) 
        //Spawns a new level part after the previous one
        int startingSpawnedLevelParts = 3;
        for (int i = 0; i < startingSpawnedLevelParts; i++)
            //as long as i (minimum is set to 0 in this case) is not 0 and less than 5, it will do the following:
            //ASK ZACH about that def to clarify ^
        {
            SpawnLevelPart();
        }
    }
    private void Update()
    {
        if ((Vector3.Distance(player.transform.position, lastEndPosition) < SpawnDistance) && !HasEndSpawned)
            //Gets the distance between (a) and (b) and checks if its less than the declared minimum spawn distance.
        {
            SpawnLevelPart();
        }
        if (chunkCount >= 12 && !HasEndSpawned)
        {
            Transform levelPartTransform = Instantiate(LevelPartEnd, lastEndPosition, Quaternion.identity);
            HasEndSpawned = true;
        }

    }





    private void SpawnLevelPart()
        //this will calculate a spawn position
        //takes a Vector3  
    {
        Transform lastLevelPartTransform = SpawnLevelPart(lastEndPosition);
        //This part, unless im mistaken, is the actual spawn code. Spawns at last end position, which is the
        // EndPosition's position
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevelPart(Vector3 spawnPos)
    //Return a transform to locate the next one
    //New function. Recieves a vector 3
    {
        int RandomLevelPart = Random.Range(0, LevelPart.Length);
        Transform levelPartTransform = Instantiate(LevelPart[RandomLevelPart], spawnPos, Quaternion.identity);
        chunkCount += 1;
        return levelPartTransform;
        //Gives the instantiated part's transform back to SpawnLevelPart in Start
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{   
    public Transform Level0_1;
    public List<Transform> levelPartList;

    
    private Vector3 lastEndPosition;

    private const float SpawnDistance = 150f;
    //How far ahead the world will generate
    public GameObject player;


    // Start is called before the first frame update
    private void Awake()
    {
        lastEndPosition = Level0_1.Find("EndPosition").position;
        SpawnLevelPart();
        //This calls the SpawnLevelPart f(x) 
        //Spawns a new level part after the previous one
        int startingSpawnedLevelParts = 5;
        for (int i = 0; i < startingSpawnedLevelParts; i++)
            //as long as i (minimum is set to 0 in this case) is not 0 and less than 5, it will do the following:
            //ASK ZACH about that def to clarify ^
        {
            SpawnLevelPart();
        }
    }
    private void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) < SpawnDistance)
            //Gets the distance between (a) and (b) and checks if its less than the declared minimum spawn distance.
        {
            SpawnLevelPart();
        }
    }
    private void SpawnLevelPart()
        //this will calculate a spawn position
        //takes a Vector3  
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        //This part, unless im mistaken, is the actual spawn code. Spawns (chosenLevelPart) at last end position, which is the
        // EndPosition's position
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevelPart(Transform.levelPart, Vector3 spawnPos)
    //Return a transform for the level part
    //Return a transform to locate the next one
    //New function. Recieves a vector 3
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPos, Quaternion.identity);
        return levelPartTransform;
        //Gives the instantiated part's transform back to SpawnLevelPart in Start
    }
}

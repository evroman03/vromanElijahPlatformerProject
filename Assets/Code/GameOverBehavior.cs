using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class GameOverBehavior : MonoBehaviour
{
    public GCBehavior GC;
    public TMP_Text FinalScore;
    public TMP_Text ShieldsCollected;
    public TMP_Text DranksDrunk;
    public TMP_Text Highscore;
    public TMP_Text MostDranksDrunk;
    public TMP_Text MostShieldsCollected;
    public TMP_Text YourTime;
    public TMP_Text FastestTime;

    // Start is called before the first frame update
    void Start()
    {
        GC = GetComponent<GCBehavior>();
        UpdateFinalScore();
    }
    public void UpdateFinalScore()
    {
        FinalScore.text = "Your Score: " + GCBehavior.Score;
        Highscore.text = "HighScore: " + GCBehavior.HighScore;

        ShieldsCollected.text = "Shields Collected: " + GCBehavior.StoredSC;
        

        DranksDrunk.text = "Dranks Drunk: " + GCBehavior.StoredDD;


    }
    
    public void Restart()
    {
        GCBehavior.Score = 0;
        GCBehavior.Shield = 0;
        GCBehavior.Drank = 0;
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

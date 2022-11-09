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
    
    public int FS;
    public int SC;
    public int DD;
    // Start is called before the first frame update
    void Start()
    {
        GC = GetComponent<GCBehavior>();
        FS = GCBehavior.Score;
        SC = GCBehavior.StoredSC;
        DD = GCBehavior.StoredDD;   
        UpdateFinalScore();

    }
    public void UpdateFinalScore()
    {
        FinalScore.text = "Highscore: " + FS;
        ShieldsCollected.text = "Shields Collected: " + SC;
        DranksDrunk.text = "Dranks Drunk: " + DD;
    }
    public void Restart()
    {
        
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

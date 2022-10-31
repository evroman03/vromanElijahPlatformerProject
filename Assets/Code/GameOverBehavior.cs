using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class GameOverBehavior : MonoBehaviour
{
    public GCBehavior GC;
    public TMP_Text FinalScore;
    public int FS;
    // Start is called before the first frame update
    void Start()
    {
        GC = GetComponent<GCBehavior>();
        FS = GCBehavior.Score;
        UpdateFinalScore();

    }
    public void UpdateFinalScore()
    {
        FinalScore.text = "Highscore: " + FS;
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

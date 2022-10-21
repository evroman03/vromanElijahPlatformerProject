using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GCBehavior : MonoBehaviour
{
    public TMP_Text LivesText;
    public TMP_Text ScoreText;
    public int Lives = 1;
    public int Score;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateLives()
    {
        Lives -= 1;
        LivesText.text = "Lives: " + Lives;
        if (Lives <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
    public void UpdateScorePwrUp()
    {
        Score += 250;
        ScoreText.text = "Score: " + Score;
    }
    public void UpdateScoreEnemy()
    {
        Score += 1000;
        ScoreText.text = "Score: " + Score;
    }
    public void UpdateScoreReflectFB()
    {
        Score += 500;
        ScoreText.text = "Score: " + Score;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GCBehavior : MonoBehaviour
{
   
    public TMP_Text ShieldText;
    public TMP_Text ScoreText;
    public TMP_Text DrankText;
    public TMP_Text StopwatchText;

    public GameObject LoseScreen;

    public float Stopwatch;

    public int Lives = 1;
    public int Shield = 0;
    public int Drank = 0;
    public int Score;

    public static bool batCooldown = false;


    // Start is called before the first frame update
    void Start()
    {
        Stopwatch = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Stopwatch = Stopwatch + Time.deltaTime;
        StopwatchText.text = " " + Stopwatch;
        if (Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            LoseScreen.SetActive(false);
        }
    }
    public void UpdateLives()
    {
        Lives -= 1;

        if (Lives <= 0 && Shield == 0)
        {
            LoseScreen.SetActive(true);
        }
        else if (Lives <= 0 && Shield == 1)
        {
            Shield -= 1;
            ShieldText.text = "x " + Shield;
        }
    }
    public void UpdateScoreBonus()
    {
        Score += 250;
        ScoreText.text = "x" + Score;
    }
    public void UpdateScoreEnemy()
    {
        Score += 1000;
        ScoreText.text = "x" + Score;
    }
    public void UpdateScoreReflectFB()
    {
        Score += 500;
        ScoreText.text = "x" + Score;
    }
    public void UpdateShield()
    {
        Shield += 1;
        ShieldText.text = "x" + Shield;

    }
    public void UpdateDrank()
    {
        Drank += 1;
        DrankText.text = "x" + Drank;
    }
    
}

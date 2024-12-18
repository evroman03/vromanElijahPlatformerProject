using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GCBehavior : MonoBehaviour
{
   
    public TMP_Text ShieldText;
    public TMP_Text ScoreText;
    public TMP_Text DrankText;
    public TMP_Text StopwatchText;

    public GameObject LoseScreen;

    public AudioClip LoseLife;
    public AudioClip ScoreEnemy;
    public AudioClip ShieldSound;
    public AudioClip DrankSound;
    public AudioClip Trophy;

    public static float Stopwatch;

    public static int Lives = 1;
    public static int Shield = 0;
    public static int Drank = 0;

    public static int Score;
    public static int StoredSC;
    public static int StoredDD;
    public static int HighScore = 0;

    public static bool BatCooldown = false;


    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "x" + Score;
        ShieldText.text = "x" + Shield;
        DrankText.text = "x" + Drank;
        StopwatchText.text = " " + Stopwatch;
        Stopwatch = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Stopwatch = Stopwatch + Time.deltaTime;
        StopwatchText.text = " " + Stopwatch.ToString("0.00");

        if (Input.GetKey(KeyCode.Escape))

        {

            Application.Quit();

        }

        else if (Input.GetKey(KeyCode.R))

        {

            UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        }

    }
    public void UpdateLives()
    {
        Lives -= 1;

        if (Lives <= 0 && Shield == 0)
        {
            if (Score >= HighScore)
            {
                HighScore = Score;
            }
            SceneManager.LoadScene(4);

        }
        else if (Lives <= 0 && Shield == 1)
        {
            Shield -= 1;
            ShieldText.text = "x " + Shield;
            AudioSource.PlayClipAtPoint(LoseLife, Camera.main.transform.position);
        }
    }
    public void UpdateScoreBonus()
    {
        Score += 250;
        ScoreText.text = "x" + Score;
        AudioSource.PlayClipAtPoint(Trophy, Camera.main.transform.position);
    }
    public void UpdateScoreEnemy()
    {
        Score += 1000;
        ScoreText.text = "x" + Score;
        AudioSource.PlayClipAtPoint(ScoreEnemy, Camera.main.transform.position);
    }
    public void UpdateScoreReflectFB()
    {
        Score += 2000;
        ScoreText.text = "x" + Score;
        AudioSource.PlayClipAtPoint(ScoreEnemy, Camera.main.transform.position);
    }
    public void UpdateShield()
    {
        Shield += 1;
        ShieldText.text = "x" + Shield;
        StoredSC += 1;
        AudioSource.PlayClipAtPoint(ShieldSound, Camera.main.transform.position);
    }
    public void UpdateDrank()
    {
        Drank += 1;
        DrankText.text = "x" + Drank;
        StoredDD += 1;
        AudioSource.PlayClipAtPoint(DrankSound, Camera.main.transform.position);
    }
    
}

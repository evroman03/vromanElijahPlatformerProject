using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GCBehavior : MonoBehaviour
{
    public TMP_Text ShieldText;
    public TMP_Text ScoreText;
    public TMP_Text DrankText;

    public int Lives = 1;
    public int Shield = 0;
    public int Drank = 0;
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

        if (Lives <= 0 && Shield == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
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

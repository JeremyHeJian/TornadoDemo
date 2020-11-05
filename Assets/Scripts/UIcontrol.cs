using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontrol : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;
    private int score = 0;
    public float time = 5;

    public GameObject gameoverUI;
    public Text gameoverCurScore;
    public Text gameoverHighScore;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        timeText.text = time.ToString();
        scoreText.text = score.ToString();
    }

    void Update()
    {
        time -= Time.deltaTime;
        timeText.text = time.ToString();

        if (time <= 0)
        {
            //end game
            Time.timeScale = 0;
            timeText.text = 0.ToString();
            if (score > PlayerPrefs.GetInt("Highscore", 0))
            {
                PlayerPrefs.SetInt("Highscore", score);
            }
            gameoverCurScore.text = score.ToString();
            gameoverHighScore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
            gameoverUI.SetActive(true);
        }
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();

    }
}

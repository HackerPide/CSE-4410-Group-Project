using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    int score = 0;
    int highscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " Points";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO Create Logic for accurately assessing points on enemy kills. Also create logic for keeping high score.
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
        score += 1;
        scoreText.text = score.ToString() + " Points";
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
        score -= 1;
        scoreText.text = score.ToString() + " Points";
        }
    }
}
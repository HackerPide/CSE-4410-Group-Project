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

    private void OnEnable() {
        Messenger.AddListener(GameEvent.ENEMY_DEATH, OnScoreChange);
        Messenger.AddListener(GameEvent.PLAYER_LIFE_STATUS, OnPlayerDeath);
    }

    private void OnDisable() {
        Messenger.RemoveListener(GameEvent.ENEMY_DEATH, OnScoreChange);
        Messenger.RemoveListener(GameEvent.PLAYER_LIFE_STATUS, OnPlayerDeath);
    }

    private void OnScoreChange() {
        score += 1;
        if (score > highscore) {
            highscore = score;
        }
    }

    private void OnPlayerDeath() {
        score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " Points";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    // Update is called once per frame
    /*void Update()
    {
        //TODO Create Logic for accurately assessing points on enemy kills. Also create logic for keeping high score.
        //Completed by Cam
    }*/
}
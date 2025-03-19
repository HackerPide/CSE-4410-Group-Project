using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public TMP_Text goldText;
    public GameObject mc;
    int score = 0;
    int highscore = 0;
    int gold;

    private void OnEnable() {
        Messenger.AddListener(GameEvent.ENEMY_DEATH, OnScoreChange);
        Messenger.AddListener(GameEvent.PLAYER_RESET, OnReset);
    }

    private void OnDisable() {
        Messenger.RemoveListener(GameEvent.ENEMY_DEATH, OnScoreChange);
        Messenger.RemoveListener(GameEvent.PLAYER_RESET, OnReset);
    }

    private void OnScoreChange() {
        score += 1;
        if (score > highscore) {
            highscore = score;
        }
    }

    private void OnReset() {
        score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " Points";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
        PlayerCharacter player = mc.GetComponent<PlayerCharacter>();
        gold = player.getGold();
        goldText.text = "Gold: " + gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString() + " Points";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
        PlayerCharacter player = mc.GetComponent<PlayerCharacter>();
        gold = player.getGold();
        goldText.text = "Gold: " + gold.ToString();
    }
}
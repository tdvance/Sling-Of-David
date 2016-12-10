using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Game : MonoBehaviour {
    public ScoreDisplay scoreDisplay;
    public ScoreDisplay highScore;
    public string HighScoreKey = "High Score";
    public string LevelName = "The Beginning";

    string key;

    float score;

    // Use this for initialization
    void Start() {
        scoreDisplay.prefixText = "Score: ";
        highScore.prefixText = "High Score: ";
        key = "Level[" + LevelName + "].(" + HighScoreKey + ")";
        LoadHighScore(key);
        scoreDisplay.transform.GetChild(0).GetComponent<Text>().color = new Color(146f / 255f, 178f / 255f, 82f / 255f);
    }

    // Update is called once per frame
    void Update() {

    }

    public void Score(float amount) {
        score += amount;
        scoreDisplay.score = (int)score;
        if (scoreDisplay.score > highScore.score) {
            scoreDisplay.transform.GetChild(0).GetComponent<Text>().color = new Color(255f / 255f, 210f / 255f, 77f / 255f);
        }
    }

    public void LoadHighScore(string key) {
        highScore.score = PlayerPrefs.GetInt(key);
    }

    public void SaveHighScore(string key) {
        if (scoreDisplay.score > highScore.score) {
            highScore.score = scoreDisplay.score;
            PlayerPrefs.SetInt(key, highScore.score);
        }
    }
}

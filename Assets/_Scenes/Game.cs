using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public ScoreDisplay score;
    public ScoreDisplay highScore;
    public string HighScoreKey = "High Score";
    public string LevelName = "The Beginning";

    string key;
    // Use this for initialization
    void Start() {
        score.prefixText = "Score: ";
        highScore.prefixText = "High Score: ";
        key = "Level[" + LevelName + "].(" + HighScoreKey + ")";
        LoadHighScore(key);
    }

    // Update is called once per frame
    void Update() {

    }

    public void LoadHighScore(string key) {
        highScore.score = PlayerPrefs.GetInt(key);
    }

    public void SaveHighScore(string key) {
        if (score.score > highScore.score) {
            highScore.score = score.score;
            PlayerPrefs.SetInt(key, highScore.score);
        }
    }
}

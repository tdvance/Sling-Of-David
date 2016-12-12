using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Responsible for scores, levels.
/// </summary>
public class Level : MonoBehaviour {
    public ScoreDisplay scoreDisplay;
    public ScoreDisplay highScoreDisplay;
    public string HighScoreKeySuffix = "High Score";
    public string LevelName = "The Beginning";

    string keyForStoringHighScoresPerLevel;
    float score;

    // Use this for initialization
    void Start() {
        scoreDisplay.prefixText = "Score: ";
        highScoreDisplay.prefixText = "High Score: ";
        keyForStoringHighScoresPerLevel = "Level[" + LevelName + "].(" + HighScoreKeySuffix + ")";
        LoadHighScore(keyForStoringHighScoresPerLevel);
        scoreDisplay.transform.GetChild(0).GetComponent<Text>().color = new Color(146f / 255f, 178f / 255f, 82f / 255f);
    }

    public void Score(float amount) {
        score += amount;
        scoreDisplay.score = (int)score;
        if (scoreDisplay.score > highScoreDisplay.score) {
            scoreDisplay.transform.GetChild(0).GetComponent<Text>().color = new Color(255f / 255f, 210f / 255f, 77f / 255f);
        }
    }

    public void LoadHighScore(string key) {
        highScoreDisplay.score = PlayerPrefs.GetInt(key);
    }

    public void SaveHighScore(string key) {
        if (scoreDisplay.score > highScoreDisplay.score) {
            highScoreDisplay.score = scoreDisplay.score;
            PlayerPrefs.SetInt(key, highScoreDisplay.score);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public string currentLevel = "Level_001";
    public string nextLevel = "Level_001";

    public int numberOfEnemies = 0;
    public float tickRate = 0.789f;
    public string levelNumberFormat = "000";

    float timeSinceLastTick;
    GameObject allEnemies;

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        Tick(0);
    }

    // Update is called once per frame
    void Update() {
        timeSinceLastTick += Time.deltaTime;
        if (timeSinceLastTick >= tickRate) {
            Tick(timeSinceLastTick);
        }
    }

    void Tick(float deltaTime) {
        timeSinceLastTick = 0f;
        numberOfEnemies = CountEnemies();
    }

    public int CountEnemies() {
        if (!allEnemies) {
            SetAllEnemiesHolder();
            if (!allEnemies) {
                return 0;
            }
        }
        return allEnemies.transform.childCount;
    }

    public void UnlockNextLevel() {
        int currentLevelIndex = int.Parse(currentLevel.Substring(currentLevel.IndexOf("_") + 1));
        nextLevel = currentLevel.Substring(0, currentLevel.IndexOf("_") + 1) + (currentLevelIndex + 1).ToString(levelNumberFormat);
        GameObject.Find("Next Level").GetComponent<Button>().interactable = true;   
    }

    void SetAllEnemiesHolder() {
        if (!allEnemies) {
            allEnemies = GameObject.Find("AllEnemies");
        }
        if (!allEnemies) {
            GameObject obj = GameObject.FindGameObjectWithTag("Enemy");
            if (obj) {
                allEnemies = obj.transform.parent.gameObject;
            }
        }
    }
}

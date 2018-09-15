using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject[] hazards;
    public GameObject boss;
    public Vector3 spawnValues;
    public int hazardsPerWave = 10;
    public int wavesPerLevel = 2;

    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
    private bool endBossReached;
    private bool restart;
    private int score;

    void Start() {
        //initialize values
        gameOver = false;
        restart = false;
        endBossReached = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;

        //Refresh UI
        UpdateScore();

        //spawn waves
        StartCoroutine(SpawnWaves());
    }

    void Update() {
        if (!restart)
            return;

        //if the restart is active, wait for restart key
        if (Input.GetKeyDown(KeyCode.R)) {
            //...and reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    IEnumerator SpawnWaves() {
        //wait some time at the beginning
        yield return new WaitForSeconds(startWait);

        int waves = 0;

        //endlessly do the whole loop
        while (true) {

            if (waves < wavesPerLevel) {
                //spawn a wave
                yield return SpawnWave();
                yield return new WaitForSeconds(waveWait);
                waves++;
            } else {
                if (!endBossReached) {
                    //spawn boss
                    InstantiateGameObject(boss);
                    endBossReached = true;
                }
            }




            if (gameOver) {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
            yield return 0;
        }
    }

    IEnumerator SpawnWave() {
        //spawn hazardCount times a hazard --> one wave
        for (int i = 0; i < hazardsPerWave; i++) {
            //spawn a hazard
            GameObject hazard = hazards[Random.Range(0, hazards.Length)];
            InstantiateGameObject(hazard);
            yield return new WaitForSeconds(spawnWait);
        }
    }

    private void InstantiateGameObject(GameObject go) {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(go, spawnPosition, spawnRotation);
    }

    public void AddScore(int newScoreValue) {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore() {
        scoreText.text = "Score: " + score;
    }

    public void GameOver() {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
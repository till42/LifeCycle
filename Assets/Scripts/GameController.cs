using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class GameController : MonoBehaviour {

    public List<WaveDefinition> waveDefinitions;

    public Vector3 spawnValues;

    public GameObject boss;
    public Canvas canvas;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Sprite HealthSprite;
    public Text scoreText;
    public Text restartText;
    private bool gameOver;
    private bool endBossReached;
    private bool restart;
    private int score;
    private int waveCount = 0;
    public GameObject bike;

    private GameObject gameoverSign;
    void Start() {
        //initialize values
        gameoverSign = GameObject.FindGameObjectWithTag("GameOver");
        gameoverSign.SetActive(false);
        gameOver = false;
        restart = false;
        endBossReached = false;
        restartText.text = "";
        score = 0;
        waveCount = 0;

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



        //endlessly do the whole loop
        while (true) {

            if (waveCount < waveDefinitions.Count) {
                //spawn a wave
                yield return SpawnWave(waveCount);
                yield return new WaitForSeconds(waveWait);
                waveCount++;
            } else {
                if (!endBossReached) {
                    //spawn boss
                    InstantiateGameObject(boss);
                    PopulateHealthCanvas();
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

    private void PopulateHealthCanvas()
    {
        int numberOfMaxHealth = boss.GetComponent<DestroyByContact>().Health;
        for(int i = 0; i < numberOfMaxHealth; i++)
        {
            GameObject heart = CreateHealthGameObject();
            heart.name = i.ToString();
            heart.transform.SetParent(canvas.transform, false);
        }
        Canvas.ForceUpdateCanvases();
    }

    private GameObject CreateHealthGameObject()
    {
        GameObject heart = new GameObject();
        Image imageSprite = heart.AddComponent<Image>();
        imageSprite.sprite = HealthSprite;
        RectTransform rectTrans = heart.GetComponent<RectTransform>();
        rectTrans.sizeDelta = new Vector2(32, 32);
        return heart;
    }

    public void DestroyHealthInCanvas()
    {
        Debug.Log(canvas.transform.GetChild(0).gameObject.name);
        Destroy(canvas.transform.GetChild(0).gameObject);
    }

    IEnumerator SpawnWave(int waveNo) {
        WaveDefinition waveDefinition = waveDefinitions[waveNo];

        List<int> selection = new List<int>();
        //add hazardsPerWave times a 0
        for (int i = 0; i < waveDefinition.HazardsPerWave; i++) {
            selection.Add(0);
        }

        //add friendsPerWave times a 1
        for (int i = 0; i < waveDefinition.FriendsPerWave; i++) {
            selection.Add(1);
        }

        //Shuffle the list
        selection.Shuffle();

        while (selection.Count > 0) {
            //spawn a gameObject
            GameObject gameObject;

            //check if friend or hazard
            int i = selection[0];
            selection.RemoveAt(0);

            if (i == 0)
                gameObject = waveDefinition.Hazards[Random.Range(0, waveDefinition.Hazards.Count)];
            else
                gameObject = waveDefinition.Friends[Random.Range(0, waveDefinition.Friends.Count)];

            InstantiateGameObject(gameObject);

            yield return new WaitForSeconds(spawnWait);
        }


    }

    public IEnumerator ReduceSpeedGradually()
    {
        float starttime = Time.time;
        float duration = 5;
        float endtime = Time.time + duration;

        GameObject floor = GameObject.FindGameObjectWithTag("Floor");
        BGScroller floorscroller = floor.GetComponent<BGScroller>();
        float speed = floorscroller.scrollSpeed;
        while (true)
        {
            float percentage = (Time.time - starttime) / duration;
            if (percentage > 1) break;
            float currentSpeed = Mathf.Lerp(speed, 0, percentage);
            floorscroller.scrollSpeed = currentSpeed;
            Debug.Log("NEW SPEED IS : " + currentSpeed + " || floorscroller-Speed actually is: " + floorscroller.scrollSpeed + " | | t is = " + percentage);
            yield return null;
        }
    }

    public void SpawnBike()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(bike, spawnPosition, spawnRotation);
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
        scoreText.text = CurrencyController.Instance.Score.ToString();
    }



    public void GameOver() {

        gameoverSign.SetActive(true);
        gameOver = true;
    }
}
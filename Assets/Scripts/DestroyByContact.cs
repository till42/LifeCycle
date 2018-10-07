using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public int Health = 1;
    public int scoreValue;
    public GameController gameController;
    void Start() {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null) {
        }
    }

    void OnTriggerEnter(Collider other) {

        if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "SlowZone" || other.tag == "Boss") {
            return;
        }

        if (explosion != null) {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player") {
            playerCollision(other);
            Health = 0;
        }

        gameController.AddScore(scoreValue);
        destroyOther(other);

        if (this.gameObject.tag == "Boss")
        {
            gameController.DestroyHealthInCanvas();
        }
        //reduce health
        Health--;
        
        //destroy self, if health is 0
        if (Health <= 0)
        {
            Destroy(gameObject);
            if (gameObject.tag == "Boss")
            {
                gameController.PlayVictorySound();
                gameController.SpawnBike();
                gameController.StartCoroutine(gameController.ReduceSpeedGradually());             
            }
        }
        
    }

    protected virtual void playerCollision(Collider other) {
        Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        gameController.GameOver();
    }

    protected virtual void destroyOther(Collider other) {
        Destroy(other.gameObject);
    }
}
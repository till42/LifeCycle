using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public int Health = 1;
    public int scoreValue;
    private GameController gameController;

    void Start() {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null) {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other) {

        Debug.Log("Collided with " + other.name + " " + other.tag);

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
            Debug.Log("Bin IMMMMMMM Canvas Destroy");
            gameController.DestroyHealthInCanvas();
        }
        //reduce health
        Health--;
        
        //destroy self, if health is 0
        if (Health <= 0)
            
            Destroy(gameObject);
    }

    protected virtual void playerCollision(Collider other) {
        Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        gameController.GameOver();
    }

    protected virtual void destroyOther(Collider other) {
        Destroy(other.gameObject);
    }
}
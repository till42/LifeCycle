using UnityEngine;
using System.Collections;

public class DestroyOrHighFiveByContact : DestroyByContact {

    public GameObject HighFive;


    protected override void playerCollision(Collider other) {
        // Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        if(other.tag == "Player")
        {
            Vector3 midpoint = CalculateMid(this.gameObject, other.gameObject);
            InstantiateGameObject(HighFive, midpoint);
            Debug.Log("gameObject.GetComponent<AudioSource>()." + gameObject.GetComponent<AudioSource>().clip.name);
            gameController.PlayHighFive();
            other.GetComponent<PlayerCntrl>().CurrencyController.AddScore(scoreValue);
        }
    }

    protected override void destroyOther(Collider other) {

    }
    private void InstantiateGameObject(GameObject go, Vector3 collisionpoint)
    {
        Vector3 spawnPosition = collisionpoint;
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(go, spawnPosition, spawnRotation);
    }

    private Vector3 CalculateMid(GameObject origin, GameObject destination)
    {
        return ((destination.transform.position - origin.transform.position) * 0.5f) + origin.transform.position;
    }
}


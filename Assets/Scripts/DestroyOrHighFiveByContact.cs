using UnityEngine;
using System.Collections;

public class DestroyOrHighFiveByContact : DestroyByContact {

    protected override void playerCollision(Collider other) {
        // Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerCntrl>().CurrencyController.AddScore(5);
        }
    }

    protected override void destroyOther(Collider other) {

    }
}
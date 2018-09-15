using UnityEngine;
using System.Collections;

public class DestroyOrHighFiveByContact : DestroyByContact {

    protected override void playerCollision(Collider other) {
        // Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

    }

    protected override void destroyOther(Collider other) {

    }
}
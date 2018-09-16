using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBell : MonoBehaviour {

    void Start() {
        GetComponent<SpriteRenderer>().enabled = PlayerStats.BellLevel > 0;

    }

}

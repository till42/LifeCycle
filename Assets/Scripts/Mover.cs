using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
    public float speed;
    public bool triggered;
    void Start() {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void Update() {
        if (triggered)
        {
            GetComponent<Rigidbody>().velocity = transform.forward * 0;
        }
    }




}

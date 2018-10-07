using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boss")
        {
            other.gameObject.GetComponent<Done_EvasiveManeuver>().currentSpeed = 0f;
        }
    }
}

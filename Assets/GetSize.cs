using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Vector3 result = gameObject.GetComponent<Mesh>().bounds.size;
        Debug.Log("X: " + result.x + "Y: " + result.y + "Z: " + result.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

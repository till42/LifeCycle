using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {
    public float scrollSpeed;
    public float tileSizeZ;
    private float temp;
    private Vector3 startPosition;

    void Start() {
        startPosition = transform.position;
        temp = 0;
    }

    void Update() {

        float newPosition = Mathf.Repeat(temp, tileSizeZ);
        temp += Time.deltaTime * scrollSpeed;
        transform.position = startPosition + Vector3.forward * newPosition;
    }


}
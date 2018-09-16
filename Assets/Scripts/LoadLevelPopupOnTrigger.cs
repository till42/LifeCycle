using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelPopupOnTrigger : MonoBehaviour {

    public GameObject Popup;

    void OnTriggerEnter(Collider other) {
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Next Level");
        Popup.SetActive(true);
    }
}

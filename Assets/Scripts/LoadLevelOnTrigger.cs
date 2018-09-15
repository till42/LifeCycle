using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnTrigger : MonoBehaviour {

    public string LevelName = "Level01";

    void OnTriggerEnter(Collider other) {
        Debug.Log("Next Level");
        SceneManager.LoadScene(LevelName);
    }
}

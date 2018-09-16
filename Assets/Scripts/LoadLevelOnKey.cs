using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnKey : MonoBehaviour {

    public string LevelName = "Level01";

    private void Update() {
        if (Input.GetButton("Fire1"))
            SceneManager.LoadScene(LevelName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatToNextLevel : MonoBehaviour {

    public KeyCode CheatKey;

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(CheatKey)) {


            ScrollRight.NextLevel();
            SceneManager.LoadScene("Main");
        }
    }
}

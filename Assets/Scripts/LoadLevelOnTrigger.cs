﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnTrigger : MonoBehaviour {

    public string LevelName = "Level01";

    void OnTriggerEnter(Collider other) {
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(LevelName);
    }
}

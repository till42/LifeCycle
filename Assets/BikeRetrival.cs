﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BikeRetrival : MonoBehaviour {

    private GameController gameController;
    public Sprite victorySprite;

    // Use this for initialization
    void Start() {
    }




    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "PlayerSprite") {
            other.gameObject.GetComponent<Animator>().enabled = false;
            other.gameObject.GetComponent<SpriteRenderer>().sprite = victorySprite;
            gameObject.GetComponent<Mover>().speed = 0;
            other.gameObject.GetComponentInParent<PlayerCntrl>().speed = 0;
            gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(ChangeSceneRoutine());
        }
    }

    IEnumerator ChangeSceneRoutine() {
        yield return new WaitForSeconds(4);

        ScrollRight.NextLevel();
        SceneManager.LoadScene("Main");
    }
}

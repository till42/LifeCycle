using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyController : MonoBehaviour {

    public static CurrencyController Instance;
    public int Score { get; set; }


	// Use this for initialization
	void Awake () {
        GameObject.DontDestroyOnLoad(this);	
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void AddScore(int score)
    {
        Score = Score + score;
    }

    public void RemoveScore(int score)
    {
        score = Score - score;
    }

}

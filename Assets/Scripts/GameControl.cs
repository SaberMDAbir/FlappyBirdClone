﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
	public GameObject GameOverText;
    public Text CurrentScore;
    public Text HighScoreDisplay;
    public bool GameOver = false;
    public float ScrollSpeed = -1.5f; // will be accessible by the public instance object

    private int score = 0;
    private int highScore = 0;
    private string highScoreKey = "HighScore";

	// Use this for initialization
	void Awake () {
        if(instance == null) {
            instance = this;
        }
        else if(instance != this) {
            // destroy the game object that this script is attached to
            Destroy(gameObject); 
        }
	}

    // Update is called once per frame
    void Update () {
        // game needs to be over and the player has attempted to flap
        if (GameOver == true && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScored () {
        if(GameOver) {
            return;
        }
        score++;
        CurrentScore.text = "Score: " + score.ToString();
    }

	public void BirdDied () {
        GameOverText.SetActive(true);
        GameOver = true;
    }
}

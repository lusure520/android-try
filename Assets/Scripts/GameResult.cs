using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour {

   
    private Text player;
    private Text level;
    private Text scores;

    void Start() {
        player = GameObject.Find("Player").GetComponent<Text>();
        level = GameObject.Find("Level").GetComponent<Text>();
        scores = GameObject.Find("Scores").GetComponent<Text>();
    }

    void Update()
    {
        player.text = "Player Name : " + PlayerPrefs.GetString("PlayerName");
        level.text = "Game Level: " + PlayerPrefs.GetString("PlayerLevel");
        scores.text = "Player Scores : " + PlayerPrefs.GetString("PlayerScores");
    }
 }

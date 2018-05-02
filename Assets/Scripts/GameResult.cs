using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour {

   
    private Text player;
    private Text level;
    private Text scores;

    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player").GetComponent<Text>();
        level = GameObject.Find("Level").GetComponent<Text>();
        scores = GameObject.Find("Scores").GetComponent<Text>();
    }

    // display the result for player
    void Update()
    {
        player.text = "Player Name : " + PlayerPrefs.GetString("PlayerName");
        level.text = "Game Level: " + PlayerPrefs.GetString("PlayerLevel");
        scores.text = "Player Scores : " + PlayerPrefs.GetString("PlayerScores");
    }
 }

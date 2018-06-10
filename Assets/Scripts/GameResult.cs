
using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour {

   
    public Text player;
    public Text level;
    public Text scores;

  
    void Start()
    {
        player.text = "Player Name : " + PlayerPrefs.GetString("PlayerName");
        level.text = "Game Level: " + PlayerPrefs.GetString("PlayerLevel");
        scores.text = "Player Scores : " + PlayerPrefs.GetString("PlayerScores");


        if (PlayerPrefs.GetInt("dataLogin") == 1)
        {
            db_controller db_controller = new GameObject().AddComponent<db_controller>();
            string palyerscores = PlayerPrefs.GetString("PlayerScores");
            int score = System.Convert.ToInt32(palyerscores);
            db_controller.UpdateScore(PlayerPrefs.GetString("PlayerName"), score);
        }
    }
}

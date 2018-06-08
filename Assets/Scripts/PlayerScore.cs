using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

    private Text scoreText;
    private Text levelText;

    private int score;

    
    // Use this for initialization
    void Start () {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        score = 0;
    }
	
    //check for basket catcher the egg and grow scores up.
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "egg")
        {
            target.gameObject.SetActive(false);// once catcher the egg, it will stop move and disappear
            IncreaseScores(1);
            UpdateText();
        }
    }
    public void GameRstart()
    {
        StartCoroutine(RestartGame());
    }
	// this will be used in sprint 2 to achieve restarting game 
	IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateText()
    {
        scoreText.text = GetScores().ToString();
        levelText.text = GetLevel().ToString();
    }

    public int GetScores()
    {
        return score;
    }

    public void IncreaseScores(int newScore)
    {
        score += newScore;
    }

    public int GetLevel()
    {
        return score / 20;
    }
}

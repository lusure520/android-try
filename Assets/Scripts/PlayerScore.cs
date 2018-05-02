using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

    private Text scoreText;
    private Text levelText;

    private int score = 0;
    private int level = 0;
    // Use this for initialization
    void Awake () {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        scoreText.text = "0";
        levelText.text = "0";

    }
	
    void OnTriggerEnter2D(Collider2D target)
    {
        score = Convert.ToInt32(scoreText.text);
        level = Convert.ToInt32(levelText.text);
        if (target.tag == "egg")
        {
            target.gameObject.SetActive(false);
            score++;
            scoreText.text = score.ToString();
            level = (score / 20);
            levelText.text = level.ToString();
        }
    }
	// Update is called once per frame
	IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

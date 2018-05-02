using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collector : MonoBehaviour {

    private Text scoreText;
    private Text levelText;
    private Text heartnotice;

    private int level = 0;
    private int score = 0;
    private int lost = 0;
    private int heartpoint = 5;
    private int maxHeartAmount = 5;
    public int startHeart = 5;

    public Image[] hearts;
    // Use this for initialization
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        heartnotice = GameObject.Find("HeartNotice").GetComponent<Text>();
        heartnotice.text = "The heart points:" + "5/5";
        checkHealthAmount();
    }

    // Update heart
    void checkHealthAmount()
    {
        for (int i = 0; i < maxHeartAmount; i++)
        {
            if (startHeart <= i)
            {
                hearts[i].enabled = false;
            }
            else
            {
                hearts[i].enabled = true;
            }
        }

        if (startHeart == 0)
        {

            PlayerPrefs.SetString("PlayerScores", scoreText.text);
            PlayerPrefs.SetString("PlayerLevel", levelText.text);
            SceneManager.LoadScene("GameOver");
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        
        score = Convert.ToInt32(scoreText.text);
        
        
        if (target.tag == "egg" && startHeart != 0)
        {
            //Destroy(target.gameObject);
            target.gameObject.SetActive(false);
            if(score != 0)
            {
                score--;
            }
            level = (score / 20);
            levelText.text = level.ToString();
            lost++;
            heartnotice.text = "The heart points:" + (5-lost)+"/5";
            if ((lost / heartpoint) == 1)
            {
                startHeart--;
                lost = 0;
                heartnotice.text = "The heart points:" + "5/5";
            } 
            checkHealthAmount();
            scoreText.text = score.ToString();
        }
    }
}

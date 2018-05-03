using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collector : MonoBehaviour {

    private Text scoreText;
    private Text levelText;
    private Text heartnotice;

    private int lostedPoint, startHeart;
    private int HEARTPOINTS = 5;
    private int MAXHEARTAMOUNT = 5;

    public Image[] hearts;

    // use for testing
    public void Construct(int lost, int start)
    {
        lostedPoint = lost;
        startHeart = start;
    }

    // Use this for initialization
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        heartnotice = GameObject.Find("HeartNotice").GetComponent<Text>();
        UpdateHeartPoint(GetHeartPoint());
        Construct(0, 5);
        CheckHealthAmount();
    }

    // Update heart
    void CheckHealthAmount()
    {
        // update hearts
        for (int i = 0; i < MAXHEARTAMOUNT; i++)
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
        // once heart be zero, junp to game over 
        if (startHeart == 0)
        {
            PlayerPrefs.SetString("PlayerScores", scoreText.text);
            PlayerPrefs.SetString("PlayerLevel", levelText.text);
            SceneManager.LoadScene("GameOver");
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "egg" && startHeart != 0)
        {
            //Destroy(target.gameObject);
            target.gameObject.SetActive(false);
            HeartPointUpdate();
            CheckHealthAmount();
        }
    }

    //update heart points
    void HeartPointUpdate()
    {
        int losted = GetLostHeartPoint() + 1;// lost one heartpoint 
        //heart points update
        SetLostHeartPoint(losted);
        if (IsLostAllHeartPoint())
        {
            startHeart--;
            SetLostHeartPoint(0);
        }
        UpdateHeartPoint(GetHeartPoint());
    }

    public void UpdateHeartPoint(int heartPoints)
    {
        heartnotice.text = "The heart points:" + heartPoints + "/5";
    }

    public int GetHeartPoint()
    {
        return HEARTPOINTS - lostedPoint;
    }

    public int GetLostHeartPoint()
    {
        return lostedPoint;
    }

    public void SetLostHeartPoint(int losted)
    {
        lostedPoint = losted;
    }

    public Boolean IsLostAllHeartPoint()
    {
        return (lostedPoint == HEARTPOINTS) ? true : false;
    }
}

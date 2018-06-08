using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collector : MonoBehaviour {

    private Text scoreText;//an instance of score text.
    private Text levelText;//an instance of level text.
    private Text heartnotice;//an instance of heartpoint text.

    private int lostPoint, startHeart;//a varible of lostPoint and statHeart.
    private static int HEARTPOINTS = 5;//a static varible of points for each heart.
    private static int MAXHEARTAMOUNT = 5;//a static varible of maximum heart amount.

    public Image[] hearts;//an array of heart.

    // Construct()
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    // Use this for testing.
    // 
    // lost   The number of lost point for each heart.
    // start  The number of start heart.
    public void Construct(int lost, int start)
    {
        lostPoint = lost;
        startHeart = start;
    }

    // Start()
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    // Use this for initialization
    //
    // When game is started, instance of score, level and heart point will be created.
    // The heart point and amount of heart will be initialized by method: construct() and updateHeartPoint().
    // The heart will be initialized by method: CheckHealthAmount().
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        heartnotice = GameObject.Find("HeartNotice").GetComponent<Text>();
        Construct(0, 5);
        UpdateHeartPointText(GetHeartPoint());        
        CheckHealthAmount();
    }

    // CheckHealthAmount()
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    // Use this for Update heart.
    //
    // The method is used to update the heart during playing game and jump to the game over when heart is zero.
    void CheckHealthAmount()
    {
        // update and control hearts display.
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
        // once heart be zero, jump to game over. 
        if (startHeart == 0)
        {
            PlayerPrefs.SetString("PlayerScores", scoreText.text);// Create a varible in PlayerPrefs to transfer the scores to result board.
            PlayerPrefs.SetString("PlayerLevel", levelText.text);// Create a varible in PlayerPrefs to transfer the level to result board.
            SceneManager.LoadScene("GameOver");// loading "GameOver" scene using secene manager.
        }
    }

    // OnTriggerEnter2D()
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    // Use this for catch the missed eggs.
    //
    // target  An parameter of the Collider2D to set up with UI collector. 
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

    // HeartPointUpdate()
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    // Use this for updating heart points
    void HeartPointUpdate()
    {
        int lost = GetLostHeartPoint() + 1;// lost one heartpoint 
        //heart points update
        SetLostHeartPoint(lost);
        if (IsLostAllHeartPoint())
        {
            startHeart--;
            SetLostHeartPoint(0);
        }
        UpdateHeartPointText(GetHeartPoint());
    }

    // IsLostAllHeartPoint()
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    // Use this for checking the point of each heart is lost.
    //
    // returns  True if lost all point of a heart, or false if it has point.
    public Boolean IsLostAllHeartPoint()
    {
        return (lostPoint == HEARTPOINTS) ? true : false;
    }

    // UpdateHeartPointText()
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    // Use this for updating the text of heart point.
    //
    // heartpoints  the number of heart points.
    public void UpdateHeartPointText(int heartPoints)
    {
        heartnotice.text = "The heart points:" + heartPoints + "/5";
    }

    // GetHeartPoint()
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    // Use this for get heart piont.
    public int GetHeartPoint()
    {
        return HEARTPOINTS - lostPoint;
    }

    // GetLostHeartPoint()
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    // Use this for get lost heart point.
    public int GetLostHeartPoint()
    {
        return lostPoint;
    }

    // SetLostHeartPoint()
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    // Use this for set lost heart point.
    public void SetLostHeartPoint(int lost)
    {
        lostPoint = lost;
    }

    
}

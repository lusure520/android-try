using System.Collections;
using UnityEngine;

public enum GameState
{
    Running,
    Pause
}

public class EggAction : MonoBehaviour {
    public static EggAction _instance;
    public GameState gamestate = GameState.Running;
    [SerializeField]
    private GameObject egg;
    private BoxCollider2D col;
    private int gameLevel = 1;

    float x1, x2;
    // Use this for initialization
    void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        _instance = this;
    }
    // Use this for initialization
    void Start () {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            if (PlayerPrefs.HasKey("GameLevel"))
            {
                gameLevel = PlayerPrefs.GetInt("GameLevel");
            }        
            StartCoroutine(SpawnEgg(1f));
        }        
    }
	
	// Update is called once per frame
	IEnumerator SpawnEgg(float time)
    {
<<<<<<< HEAD
        yield return new WaitForSecondsRealtime(time);// control the second egg spawn
=======
        yield return new WaitForSecondsRealtime(time / gameLevel);// control the second egg spawn
>>>>>>> Bin_Jiang

        x1 = transform.position.x - col.bounds.size.x / 2f;
        x2 = transform.position.x + col.bounds.size.x / 2f;

        Vector3 temp = transform.position;
        temp.x = Random.Range(x1, x2);// get random x position to falling egg down
        Instantiate(egg, temp, Quaternion.identity);
        if(gamestate == GameState.Running)
        {
            StartCoroutine(SpawnEgg(Random.Range(1f, 2f))); 
        }
    }

    public void transformGameState()
    {
        if(gamestate == GameState.Running)
        {
            GamePause();
        }
        else
        {
            ContinueGame();
        }
    }

    public void GamePause()
    {
        Time.timeScale = 0;
        gamestate = GameState.Pause;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        gamestate = GameState.Running;
        StartCoroutine(SpawnEgg(1f));
    }
}

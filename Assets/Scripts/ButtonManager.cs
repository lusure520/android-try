using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private InputField nameInput;
    public Text Gamelevel;
    void Start()
    {
        Gamelevel.text = "GameLevel: 1";
        if (PlayerPrefs.HasKey("GameLevel"))
        {
            Gamelevel.text = "GameLevel: " + PlayerPrefs.GetInt("GameLevel");
        }
    }

    public void StartSimpleGame()
    {
        PlayerPrefs.SetInt("GameLevel", 1);
        SceneManager.LoadScene("Menu");
    }

    public void StartMiddleGame()
    {
        PlayerPrefs.SetInt("GameLevel", 2);
        SceneManager.LoadScene("Menu");
    }

    public void StartHardGame()
    {
        PlayerPrefs.SetInt("GameLevel", 3);
        SceneManager.LoadScene("Menu");
    }

    public void StartGame(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);// to jump to the scenes by the specific scenes name
    }
    
    public void ExitGame()
    {
        PlayerPrefs.DeleteAll();// delete all data in playerprefs
        SceneManager.LoadScene("Menu");
    }

    public void LoginButton(string LoginPage)
    {
        SceneManager.LoadScene(LoginPage);
    }

    public void SubmitName(string submitlevel)
    {
        nameInput = GameObject.Find("NameInput").GetComponent<InputField>();
        PlayerPrefs.SetString("PlayerName", nameInput.text);// to associate a data and a key value to transform date.
        PlayerPrefs.SetInt("dataLogin", 0);
        SceneManager.LoadScene(submitlevel);
    }
}

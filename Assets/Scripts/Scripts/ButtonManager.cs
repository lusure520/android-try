using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private InputField nameInput;

    public void StartGame(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);// to jump to the scenes by the specific scenes name
    }
    public void HelpButton(string Helplevel)
    {
        SceneManager.LoadScene(Helplevel);
    }
    public void CloseButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ExitGame()
    {
        PlayerPrefs.DeleteAll();// delete all data in playerprefs
        SceneManager.LoadScene("Menu");
    }
    public void SubmitName(string submitlevel)
    {
        nameInput = GameObject.Find("NameInput").GetComponent<InputField>();
        PlayerPrefs.SetString("PlayerName", nameInput.text);// to associate a data and a key value to transform date.
        SceneManager.LoadScene(submitlevel);
    }
}

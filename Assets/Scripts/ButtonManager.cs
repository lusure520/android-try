using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private InputField nameInput;
// inital game level
    public void StartGame(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }
// inital help button
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
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Menu");
    }
    public void SubmitName(string submitlevel)
    {
        nameInput = GameObject.Find("NameInput").GetComponent<InputField>();
        PlayerPrefs.SetString("PlayerName", nameInput.text);
        SceneManager.LoadScene(submitlevel);
    }
}

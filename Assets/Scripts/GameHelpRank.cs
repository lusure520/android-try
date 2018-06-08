using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelpRank : MonoBehaviour {

    public GameObject Panel;
    public GameObject RankPanel;
    public Text ranks;
    // Use this for initialization
    void Start () {
        Panel.gameObject.SetActive(false);
        RankPanel.gameObject.SetActive(false);
       
    }

    public void ShowHelp()
    {
        Panel.gameObject.SetActive(true);
    }
    public void CloseButton()
    {
        Panel.gameObject.SetActive(false);
        RankPanel.gameObject.SetActive(false);
    }

    public void ShowRank()
    {
        db_controller db_controller = new GameObject().AddComponent<db_controller>();
        ranks.text = db_controller.GameRank();
        RankPanel.gameObject.SetActive(true);
    }

}

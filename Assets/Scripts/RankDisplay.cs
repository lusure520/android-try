using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankDisplay : MonoBehaviour {

    public GameObject RankPanel;
    // Use this for initialization
    void Start () {
        RankPanel.gameObject.SetActive(false);
    }

    public void ShowRank()
    {
        //SceneManager.LoadScene(Helplevel);
        RankPanel.gameObject.SetActive(true);
    }
    public void CloseButton()
    {
        RankPanel.gameObject.SetActive(false);
    }
}

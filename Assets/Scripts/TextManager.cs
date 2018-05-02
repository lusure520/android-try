using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class TextManager : MonoBehaviour
{

   Text title;
    string playername;

    // Use this for initialization
    void Update() {
        title =GetComponent<Text>();
        playername = PlayerPrefs.GetString("PlayerName");
        System.DateTime currentTime = System.DateTime.Now;
        if (currentTime.Hour < 8 || currentTime.Hour > 18)
        {
            title.text = "Hi " + playername + ", Good evening.";
        }
        else if (currentTime.Hour >= 8 && currentTime.Hour < 12)
        {
            title.text = "Hi " + playername + ", Good momning.";
        }
        else
        {
            title.text = "Hi " + playername + ", Good afternoon.";
        }
    }
    
}

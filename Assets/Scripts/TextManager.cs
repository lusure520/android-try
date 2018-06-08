using UnityEngine;
using UnityEngine.UI;


public class TextManager : MonoBehaviour
{

    Text title;
    string playername;

    // Use this for check the time to notice player
    void Start() {
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

        if(PlayerPrefs.GetInt("dataLogin") == 1)
        {
            db_controller db_controller = new GameObject().AddComponent<db_controller>();
            title.text +="\n"+db_controller.GetScore(PlayerPrefs.GetString("PlayerName"));
        }
        else
        {
            title.text += "\n" +"Unsigned Player";
        }
        
    }
    
}

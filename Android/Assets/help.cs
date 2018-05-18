using UnityEngine;


public class help : MonoBehaviour
{

    // Use this for initialization  
    void Start()
    {
        
    }

    // Update is called once per frame  
    void Update()
    {

    }
    public bool WindowShow = false;
    void OnGUI()
    {
        if (GUI.Button(new Rect(310, 10, 80, 30), "Help"))
        {
                WindowShow = true;
           
        }
        if (WindowShow)
        {
            GUI.Box(new Rect(300, 20, 200, 200), "Help");
            GUILayout.BeginArea(new Rect(300, 40, 200, 200));
            GUILayout.Label("1. ");
            GUILayout.Label("2. ");
            GUILayout.Label("3. ");
            GUILayout.Label("4. ");
            GUILayout.EndArea();
            if (GUI.Button(new Rect(360, 170, 80, 30), "Close"))
            {
                WindowShow = false;
            }
        }
    }
}
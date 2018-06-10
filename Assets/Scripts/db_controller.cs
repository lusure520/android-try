using Mono.Data.Sqlite;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class db_controller : MonoBehaviour {
    public SqliteConnection con_db;
    public SqliteCommand cmd_db;
    public SqliteDataReader rdr;
    public string path;
    public Text text;

    
    string username;
    string password_c;
    int score;
    public InputField namefield;
    public InputField passwordfield;
    public void connection() {
        try
        {
            if (Application.platform != RuntimePlatform.Android)
            {
                path = Application.dataPath + "/database1.2.s3db";
            }
            else
            {
                path = Application.persistentDataPath + "/database1.2.s3db";
                if (!File.Exists(path))
                {
                    WWW load = new WWW("jar:file://" + Application.dataPath + "!/Assets/" + "/database1.2.s3db");
                    while (!load.isDone) { }
                    File.WriteAllBytes(path, load.bytes);


                }
            }
            con_db = new SqliteConnection("URI=file:" + path);
            con_db.Open();
        }
        catch (Exception ex) {
            text.text = ex.ToString();
        }
    }
    private void Disconnection() {
        con_db.Close();

    }

    public void Login() {
        connection();
        try {
            username = namefield.text.ToString();
            password_c = passwordfield.text.ToString();
            score = 0;
            if (!CheckExisting(username))
            {
                SignUp(username, password_c,score);
            }
            else
            {
                CheckPassword(username, password_c);
            }
            
        }
        catch (Exception ex)
        {
            text.text = "L"+ex.ToString();
        }
        Disconnection();
    }

    public void SignUp(string name, string password, int score)
    {
        
        try
        {
            cmd_db = new SqliteCommand("INSERT INTO users(user_name, password, score) values('" + name + "','" + password + "','"+score+"')", con_db);
            cmd_db.ExecuteNonQuery();
            CheckPassword(name,password);
        }
        catch (Exception ex)
        {
            text.text = "SU"+ex.ToString();
        }
    
    }

    private Boolean CheckExisting(string name)
    {
        Boolean check = false;
        try
        {
            cmd_db = new SqliteCommand("SELECT * FROM users", con_db);
            rdr = cmd_db.ExecuteReader();
            while (rdr.Read())
            {
                name = rdr[0].ToString();
                if (username.Equals(name))
                {
                    check = true;
                }
            }
            
        }
        catch (Exception ex)
        {
            text.text = "CE"+ex.ToString();
        }
        return check;
    }

    private void CheckPassword(string name, string password)
    {
        //String check = "aaaaaaa";
        try
        {
            cmd_db = new SqliteCommand("SELECT * FROM users", con_db);
            rdr = cmd_db.ExecuteReader();
            while (rdr.Read())
            {
                name = rdr[0].ToString();
                password = rdr[1].ToString();
                if (username.Equals(name) && password_c.Equals(password))
                {
                    PlayerPrefs.SetString("PlayerName", name);
                    PlayerPrefs.SetInt("dataLogin", 1);
                    SceneManager.LoadScene("Gameplay");
                }
                else
                {
                    text.text = "Enter Wrong Password";
                }
            }
        }
        catch (Exception ex)
        {
            text.text = "pc"+ex.ToString();
        }

    }

    public string GetScore(string username)
    {
        connection();
        string stext = " ";
        try
        {
            cmd_db = new SqliteCommand("SELECT * FROM users", con_db);
            rdr = cmd_db.ExecuteReader();
            while (rdr.Read())
            {
                name = rdr[0].ToString();
               
                if (name.Equals(username))
                {
                    stext = "Scores: "+ rdr[2].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            text.text = "GS" + ex.ToString();
        }
        Disconnection();
        return stext;
    }

    public void UpdateScore(string name, int score)
    {
        connection();
        try
        {
            cmd_db = new SqliteCommand("UPDATE users SET score='" + score +"'WHERE user_name ='" + name + "'", con_db);
            cmd_db.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            text.text = "US" + ex.ToString();
        }
        Disconnection();
    }

    public string GameRank()
    {
        string playerInfo = "";
        int number = 1;
        connection();
        try
        {
            cmd_db = new SqliteCommand("SELECT * FROM users ORDER BY score DESC LIMIT 3", con_db);
            rdr = cmd_db.ExecuteReader();
            while (rdr.Read())
            {
                playerInfo += "Top"+number+" player: "+rdr[0].ToString() +"  Scores: " +rdr[2].ToString() + "\n\n";
                number++;
            }
        }
        catch (Exception ex)
        {
            text.text = "US" + ex.ToString();
        }
        Disconnection();
        return playerInfo;
    }

}

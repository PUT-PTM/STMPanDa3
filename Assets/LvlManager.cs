﻿using UnityEngine;
using System.Collections;

public class LvlManager : MonoBehaviour
{

    public int score;
    public int lives;
    // Use this for initialization
    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            // .. then reload the currently loaded level.
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    public void AddPoints(int points)
    {
        score += points;
    }
    public void DecLives()
    {
        lives--;
    }
    private GUIStyle guiStyle = new GUIStyle(); //create a new variable

    void OnGUI()
    {
        guiStyle.fontSize = 50;
        GUI.contentColor = Color.black;
        GUILayout.Label(score.ToString() + "\nlives:" + lives.ToString(), guiStyle);
    }
}

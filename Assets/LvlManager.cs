using UnityEngine;
using System.Collections;

public class LvlManager : MonoBehaviour
{

    public int score;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddPoints(int points)
    {
        score += points;
    }
    private GUIStyle guiStyle = new GUIStyle(); //create a new variable

    void OnGUI()
    {
        guiStyle.fontSize = 50;
        GUI.contentColor = Color.black;
        GUILayout.Label(score.ToString(), guiStyle);
    }
}

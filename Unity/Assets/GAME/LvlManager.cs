using UnityEngine;
using System.Collections;

public class LvlManager : MonoBehaviour
{
    public int highScore = 0;
    public int score = 0;
    public int lives;
    public GameObject restartText;
    // Use this for initialization
    void Start()
    {
        lives = 100;
    }

    // Update is called once per frame
    void Update()
    {

   

       if (lives <= 0)
        {
            // restartText.SetActive(true);
            highScore= PlayerPrefs.GetInt("HighScore");
            if (highScore<score)
            {
                highScore = score;
                PlayerPrefs.SetInt("HighScore", highScore);           
          
            }
            if (Input.GetButtonDown("Fire1"))
                Application.LoadLevel(Application.loadedLevel);


            Destroy(GameObject.Find("PanDa3"), 0);
            return; 
        }
    }
    public float fallSpeed()
    {
        float speed=score/100;
        return speed;
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
        guiStyle.fontSize = 35;
        GUI.contentColor = Color.black;
        highScore= PlayerPrefs.GetInt("HighScore");
        GUILayout.Label(score.ToString() + "\nHighScore: "+highScore.ToString()+ "\nlives:" + lives.ToString(), guiStyle);

    }


   

}

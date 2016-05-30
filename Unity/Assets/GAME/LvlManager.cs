using UnityEngine;
using System.Collections;
using System.Threading;

public class LvlManager : MonoBehaviour
{
    public int highScore = 0;
    public int score = 0;
    public int lives;
    public GameObject restartText1;
    public GameObject restartText2;
    public AudioClip ac1;
    public AudioClip ac2;
    public AudioClip ac3;
    public AudioClip ac4;
    public AudioClip ac5;
    AudioSource audio;
    // Use this for initialization
    void Start()
    {
        restartText1.SetActive(false);
        restartText2.SetActive(false);
        lives = 100;
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

     

        if (lives <= 0)
        {
           
            restartText1.SetActive(true);
            restartText2.SetActive(true);
            highScore = PlayerPrefs.GetInt("HighScore");
            if (highScore<score)
            {
                highScore = score;
                PlayerPrefs.SetInt("HighScore", highScore);           
          
            }
            if (Input.GetButtonDown("Fire1"))
                Application.LoadLevel(Application.loadedLevel);


            Destroy(GameObject.Find("PanDa3"), 0);
            audio.PlayOneShot(ac5, 1.0F);
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
        if(score%100==0 && score >0) audio.PlayOneShot(ac3, 1.0F);

        if (points == 10)
            audio.PlayOneShot(ac1,1.0F);
        else
            audio.PlayOneShot(ac2, 1.0F);

    }
    public void DecLives()
    {
        lives--;
        audio.PlayOneShot(ac4, 1.0F);
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

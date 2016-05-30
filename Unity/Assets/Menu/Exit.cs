using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour
{
    Vector3 moveDir = Vector3.zero;

    void OnMouseDown()
    {
        transform.localScale *= 0.9F;
    }

    void OnMouseUp()
    {
        Application.Quit();
        PlayerPrefs.DeleteKey("HighScore");
    }

    void Update()
    {
        moveDir.y = Input.GetAxis("Vertical");

        if (moveDir.y <-0.3  && Input.GetButtonDown("Fire1"))
        {
            Application.LoadLevel(1);
        PlayerPrefs.DeleteKey("HighScore");
            transform.localScale *= 0.9F;
        }

        }
}
using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour
{
    Vector3 moveDir = Vector3.zero;

    void OnMouseDown()
    {
        transform.localScale *= 1.5F;
    }

    void OnMouseUp()
    {
        Application.Quit();
        PlayerPrefs.DeleteKey("HighScore");
    }

    void Update()
    {
        moveDir.y = Input.GetAxis("Vertical");
        if (moveDir.y < -0.5 && Input.GetButtonDown("Fire1"))
        {
            Application.Quit();
            PlayerPrefs.DeleteKey("HighScore");
           transform.localScale *= 1.5F;
        }
        if (moveDir.y < -0.5)

            gameObject.GetComponent<Renderer>().material.color = Color.red;
        else
            gameObject.GetComponent<Renderer>().material.color = Color.white;

    }
}
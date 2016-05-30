using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {
 
    void OnMouseDown()
    {
        transform.localScale *= 0.9F;
    }
    Vector3 moveDir = Vector3.zero;

    void OnMouseUp()
    {
        Application.LoadLevel(1);
        
    }

    void Update()
    {
        moveDir.y = Input.GetAxis("Vertical");

        if (moveDir.y > 0.5 && Input.GetButtonDown("Fire1"))
        {
            Application.LoadLevel(1);
            transform.localScale *= 1.5F;

        }
        if (moveDir.y > 0.5)

            gameObject.GetComponent<Renderer>().material.color = Color.green;
        else
            gameObject.GetComponent<Renderer>().material.color = Color.white;

    }


}

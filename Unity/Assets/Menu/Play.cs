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

          if(moveDir.y >0.3 &&  Input.GetButtonDown("Fire1"))
        {
            Application.LoadLevel(1);
        transform.localScale *= 0.9F;
    }
}


}

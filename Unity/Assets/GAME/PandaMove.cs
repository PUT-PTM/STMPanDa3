using UnityEngine;
using System.Collections;

public class PandaMove : MonoBehaviour

{
    public float speed = 1; // speed in meters per second
   
    void Update()
    {
        Vector3 moveDir = Vector3.zero;
        moveDir.x = Input.GetAxis("Horizontal");
   
        // get result of AD keys in X
        // move this object at frame rate independent speed:

        transform.position -= moveDir *speed* Time.deltaTime;
      
        if(moveDir.x >0) transform.rotation = Quaternion.AngleAxis(0, Vector3.down); 
        if (moveDir.x < 0) transform.rotation = Quaternion.AngleAxis(180, Vector3.down);

       
       if(moveDir.x >-1 && moveDir.x<1)

            GetComponent<AudioSource>().Pause();
        else
            GetComponent<AudioSource>().UnPause();



    }


}

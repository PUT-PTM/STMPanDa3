using UnityEngine;
using System.Collections;

public class PandaMove : MonoBehaviour
{
    public float speed = 1; // speed in meters per second

    void Update()
    {
        Vector3 moveDir = Vector3.zero;
        moveDir.x = Input.GetAxis("Horizontal");
        var rot = transform.rotation;
        // get result of AD keys in X
        // move this object at frame rate independent speed:
        //   transform.position += moveDir * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.rotation = Quaternion.AngleAxis(0, Vector3.down);
            transform.position += moveDir * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
            transform.position += moveDir * speed * Time.deltaTime;
        }
    }


}

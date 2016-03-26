using UnityEngine;
using System.Collections;

public class PandaMove : MonoBehaviour
{
    /*
    // Use this for initialization
    public Rigidbody rb;
    public Collider cl;
    int predkosc = 300;
    int WysokoscSkoku = 10;
    float distToGround;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cl = GetComponent<Collider>();

        distToGround = cl.bounds.extents.y;
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
    }

    // Update is called once per frame
    void Update()
    {

        //Poruszanie sie
        float obrot = Input.GetAxis("Horizontal") * predkosc;
        obrot *= Time.deltaTime;
        rb.AddRelativeTorque(Vector3.back * obrot);

        //Skakanie
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = rb.velocity + Vector3.up * WysokoscSkoku;
        }
    }
    */


    public float speed = 1; // speed in meters per second

    void Update()
    {
        Vector3 moveDir = Vector3.zero;
        moveDir.x = Input.GetAxis("Horizontal"); // get result of AD keys in X
        // move this object at frame rate independent speed:
        transform.position += moveDir * speed * Time.deltaTime;
    }
}

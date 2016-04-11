
using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour
{
    public int sPoints = 10;

    public LvlManager lvlman;

    public Transform[] patrolPoints;
    public float moveSpeed;
    private int currentPoint;

    // Use this for initialization

    void Start()
    {
        transform.position = patrolPoints[0].position;
        currentPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == patrolPoints[currentPoint].position)
        {

            currentPoint++;
        }

        if (currentPoint == patrolPoints.Length)
        {
            transform.position = patrolPoints[0].position;
        }

        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed = Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(this.gameObject.name == "ocena2")
        {
            lvlman.AddPoints(sPoints);
        Destroy(GameObject.Find(this.gameObject.name), 0);
        }

    }



}


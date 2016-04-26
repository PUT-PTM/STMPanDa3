
using UnityEngine;
using System.Collections;
using System.Threading;

public class Patrol : MonoBehaviour
{
    public int sPoints = 10;
    public int mPoints = -30;
  
    public LvlManager lvlman;

    public Transform[] patrolPoints;
    public float moveSpeed;
    private int currentPoint;
    public int objectCount;

    // Use this for initialization

    void Start()
    {
       transform.position = patrolPoints[0].position;
        currentPoint = 0;

       
    }

    // Update is called once per frame

    void Update()
    {
        
        if (objectCount < 2)
        {
            objectCount++;

            var note = GameObject.Instantiate(this.gameObject);
          
        }
       
        if (transform.position == patrolPoints[currentPoint].position)
        {

            currentPoint++;
        }

        if (currentPoint == patrolPoints.Length)
        {
            transform.position = patrolPoints[0].position;
        }

        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed = Time.deltaTime*2);
        
    }


   
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "PanDa3")
        {
            if(this.gameObject.name == "ocena2")
            {
                lvlman.AddPoints(mPoints);
        Destroy(GameObject.Find(this.gameObject.name), 0);
            }
            else
            {
                lvlman.AddPoints(sPoints);
                Destroy(GameObject.Find(this.gameObject.name), 0);
            }
        }
        if (other.gameObject.name == "ground")
        {
            if (this.gameObject.name != "ocena2")
            {
                lvlman.DecLives();
                Destroy(GameObject.Find(this.gameObject.name), 0);
            }
            else Destroy(GameObject.Find(this.gameObject.name), 0);
        }

    }



}


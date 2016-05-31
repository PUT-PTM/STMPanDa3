
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
    public GameObject note;
    // Use this for initialization

    void DestructionM()
    {
        Destroy(this.gameObject, 0);
        lvlman.AddPoints(mPoints);
    }

    void DestructionS()
    {
        Destroy(this.gameObject, 0);
        lvlman.AddPoints(sPoints);
    }

    void DestructionD()
    {
        Destroy(this.gameObject, 0);
        lvlman.DecLives();
    }

    void Start()
    {
       transform.position = patrolPoints[0].position;
        currentPoint = 0;
       StartCoroutine(i());
    }

    IEnumerator i()
    {
        float a = 3;
        yield return new WaitForSeconds(a);
        newenemy();
    }

    void newenemy()
    {
        GameObject.Instantiate(this.gameObject);
        StartCoroutine(i());
    }
    // Update is called once per frame

    void Update()
    {

        //if ((objectCount%5<1)&&(objectCount < 100))
        //{
        //    objectCount++;

        //    var note = GameObject.Instantiate(this.gameObject);

        //}

        if (lvlman.lives<=0)
        {
            StopAllCoroutines();
        }
        if (transform.position == patrolPoints[currentPoint].position)
        {

            currentPoint++;
        }

        if (currentPoint == patrolPoints.Length)
        {
            transform.position = patrolPoints[0].position;
        }
        if (lvlman.lives <=0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPoint].position,
               moveSpeed = 0);
        }
        else
        {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPoint].position,
            moveSpeed = Time.deltaTime  * (2+lvlman.fallSpeed()));
        }
    }

   

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "PanDa3")
        {
            if(this.gameObject.name == "ocena2")
            {
                DestructionM();
            }
            else
            {
                DestructionS();
            }
        }
        if (other.gameObject.name == "ground")
        {
            lvlman.collisioncount += 1;
            if (this.gameObject.name != "ocena2")
            {
                DestructionD();
            }
            else
            {
                Destroy(this.gameObject, 0);         
            }
    }
}
}


using UnityEngine;
using System.Collections;
using System.Threading;


public class Patrol : MonoBehaviour
{
    private bool hasCollide = false;
    public int sPoints = 10;
    public int mPoints = -30;
    public LvlManager lvlman;
    public int Dlives = 0;
    public Transform[] patrolPoints;
    public float moveSpeed;
    private int currentPoint;
    public GameObject note;
    public endPositionScript end;
    private string last = string.Empty;
    private int count = 0;

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
    }

    void Update()
    {
        if (lvlman.lives <= 0)
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
        if (lvlman.lives <= 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPoint].position,
               moveSpeed = 0);
        }
        else
        {
            if (lvlman.score < 500)
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPoint].position,
                moveSpeed = Time.deltaTime * 2);
            else
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPoint].position,
            moveSpeed = Time.deltaTime * 3);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PanDa3")
        {
            if (last != this.gameObject.name || last == string.Empty)
            {
                last = this.gameObject.name;
                if (this.gameObject.name.Contains("ocena2"))
                {
                    GameObject.Instantiate(this.gameObject);
                    DestructionM();
                }
                else
                {
                    GameObject.Instantiate(this.gameObject);
                    DestructionS();
                }
            }
        }
        if (other.gameObject.name == "ground")
        {
            if (last != this.gameObject.name || last == string.Empty)
            {
                last = this.gameObject.name;
                lvlman.collisioncount += 1;
                if (this.gameObject.name.Contains("ocena2") == false)
                {
                    GameObject.Instantiate(this.gameObject);
                    DestructionD();
                }
                else
                {
                    GameObject.Instantiate(this.gameObject);
                    Destroy(this.gameObject, 0);
                }
            }
        }
    }
}
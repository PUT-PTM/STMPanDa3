using UnityEngine;
using System.Collections;

public class endPositionScript : MonoBehaviour {

	// Use this for initialization
    IEnumerator i()
    {
        float a = 6;
        yield return new WaitForSeconds(a);
        rand();
    }
    public void rand()
    {
        int RandX = Random.Range(-10, 13);
        Vector3 newPosition = new Vector3(RandX, -20, 0);
        transform.position = newPosition;
        StartCoroutine(i());
    }
	void Start ()
    {
        rand();
    }

    // Update is called once per frame
    void Update () {
	
	}
}

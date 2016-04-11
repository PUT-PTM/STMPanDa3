using UnityEngine;
using System.Collections;

public class endPositionScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        int RandX = Random.Range(-9, 10);
        Vector3 newPosition = new Vector3(RandX, -15, 0);
        transform.position = newPosition;

    }

    // Update is called once per frame
    void Update () {
	
	}
}

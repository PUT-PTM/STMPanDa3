using UnityEngine;
using System.Collections;

public class startPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
        int RandX = Random.Range(-9, 10);
        int RandY = Random.Range(-8, 9);
        Vector3 newPosition = new Vector3(0,0 , 0);
        transform.position = newPosition;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

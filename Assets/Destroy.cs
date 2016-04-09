using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    void OnCollisionEnter(Collision collisionInfo)
    {
        Destroy(collisionInfo.gameObject);
    }
    // Update is called once per frame
    void Update () {
	
	}
}

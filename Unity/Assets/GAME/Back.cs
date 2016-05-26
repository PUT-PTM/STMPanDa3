using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {

    void OnMouseDown()
    {
        transform.localScale *= 0.9F;
    }

    void OnMouseUp()
    {
        Application.LoadLevel(0);

    }
}

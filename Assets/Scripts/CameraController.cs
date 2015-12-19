using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject target;

    public float dampTime;

    private Vector3 velocity = Vector3.zero;

	void Start () {
	    
	}

	void Update () {
        
        Vector3 position = target.transform.position + new Vector3(0f, 5.6f, -2.5f);
        transform.position = Vector3.SmoothDamp(transform.position, position, ref velocity, dampTime);
    }
}

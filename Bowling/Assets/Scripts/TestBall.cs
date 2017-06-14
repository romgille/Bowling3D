using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody body = GetComponent<Rigidbody>();
        if (Input.GetMouseButtonDown(0))
        {
            body.isKinematic = false;
            body.AddForce(50 * Vector3.forward, ForceMode.Impulse);
        }
	}
}

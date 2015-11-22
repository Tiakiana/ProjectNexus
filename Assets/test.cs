using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class test : MonoBehaviour {
    Rigidbody rb;
    public GameObject qqch;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.AddForce(Vector3.up*10);
    }
}

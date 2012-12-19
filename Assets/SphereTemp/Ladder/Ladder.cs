using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		
			other.gameObject.GetComponent<Control>().onLadder = true;
			other.gameObject.GetComponent<Control>().onPlat = false;
			other.gameObject.GetComponent<Control>().rigidbody.useGravity = false;
		
	}
	
	void OnTriggerExit(Collider other)
	{
			other.gameObject.GetComponent<Control>().onLadder = false;
			other.gameObject.GetComponent<Control>().rigidbody.useGravity = true;
			other.gameObject.GetComponent<Control>().isClimbing = false;
		
	}
}

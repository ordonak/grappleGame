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
		other.gameObject.GetComponent<CharMoter>().onLadder=true;
	}
	
	void OnTriggerExit(Collider other)
	{
			other.gameObject.GetComponent<CharMoter>().onLadder = false;
			other.gameObject.GetComponent<CharMoter>().gravity = 10;
	}
}

using UnityEngine;
using System.Collections;

public class TargetSticky : MonoBehaviour {
	
	public bool hookedOn;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision c) {
        c.gameObject.GetComponent<CharMoter>().gravity = 10;
		c.gameObject.GetComponent<CharMoter>().hooking = false;
		c.gameObject.GetComponent<CharMoter>().hooked = true;
		hookedOn = true;
    }
	
	
	
	
	
}

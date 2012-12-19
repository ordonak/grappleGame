using UnityEngine;
using System.Collections;

public class TargetSticky : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision c) {
        if(c.gameObject.name == "Character"){
			var joint = gameObject.AddComponent<HingeJoint>();
        	joint.connectedBody = c.rigidbody;
		}
    }
}

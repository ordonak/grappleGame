using UnityEngine;
using System.Collections;

public class Follow: MonoBehaviour {
    public Transform target;
	public int followDistance = 10;
    void Update() {
        this.transform.position = new Vector3(followDistance,target.position.y, target.position.z);
	//	this.transform.position.x = (float)followDistance;
		 //Vector3 yo = new Vector3(followDistance,0,0);
		//this.transform.Translate(yo, target);
    }
}
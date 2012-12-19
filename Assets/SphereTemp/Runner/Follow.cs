using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

		public Transform sphere;
	// Update is called once per frame
	void Update () {
		
		this.transform.position = sphere.position;
		this.transform.Translate(0,0,-10);
	}
}

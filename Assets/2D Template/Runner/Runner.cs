using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public int moveSpeed = 5;
	// Update is called once per frame
	void Update () {

	if (Input.GetButtonDown("Horizontal"))
	{
		float h = Time.deltaTime * moveSpeed;

		transform.Translate(h,0,0);
	}
}
}

using UnityEngine;
using System.Collections;

public class LevPlat : MonoBehaviour {
	private int distToCover = 10;
	private bool up;
	private Vector3 initPos;
	// Use this for initialization
	void Start () {
		up = true;
		initPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		checkPos ();
		if(up)
			this.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
		if(!up)
			this.transform.Translate(Vector3.down * Time.deltaTime, Space.World);
	}
	
	void checkPos(){
		if(this.transform.position.y >= initPos.y+distToCover)
			up = false;
		else if(this.transform.position.y <= initPos.y)
			up = true;
	}
}

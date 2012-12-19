using UnityEngine;
using System.Collections;
	
public class Control : MonoBehaviour {

	
	
	public float speed = 5F;
	public float jumpVel = 5;
	public Vector3 velocity = new Vector3(0,0,0);
	public bool onPlat = true;
	public GameObject particle;
	private float timeLeft = 1;
	public bool onLadder;
	public bool isClimbing;
	public bool inAir;
	public bool fallWait;
	public bool hookedOn;
	public Vector3 newPos, negForce;
	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		
		if(fallWait)
			timeLeft -= Time.deltaTime;
		if(timeLeft <= 0){
			fallWait = false;
			timeLeft = 1;
			rigidbody.useGravity = true;
		}
		
		float translation = Input.GetAxis("Horizontal") * speed;
		translation *= Time.deltaTime;
		velocity = new Vector3(translation, 0, 0);	
		rigidbody.AddForce(velocity, ForceMode.VelocityChange);
		//check for jumps
		if(Input.GetButtonDown ("Vertical") && onPlat){
			velocity = new Vector3(0,jumpVel,0);
			rigidbody.AddForce (velocity,ForceMode.VelocityChange );
		}
		if(Input.GetButton ("Vertical") && onLadder){
			isClimbing = true;
			this.transform.Translate((Vector3.up * Time.deltaTime)*2, Space.World);
		}
		if(Input.GetButton ("Fire1")){
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				
				if(Physics.Raycast(ray, out hit) && hit.collider.name == "Target"){
					print ("Hit!");
					newPos =  hit.point- this.transform.position;
					negForce = this.transform.position -hit.point;
					newPos.z = this.transform.position.z;
					rigidbody.AddForce (newPos, ForceMode.VelocityChange);
				
				

					//while(this.transform.position!= newPos)
    				//this.transform.position = Vector3.Lerp(this.transform.position, newPos, Time.deltaTime * smooth);
					//this.transform.position = Vector3.MoveTowards(this.transform.position, newPos, 1);
				
					//this.transform.position = newPos;
					}
			
			
		}
	}
	void OnCollisionEnter (Collision c) {
		onPlat = true;
		inAir = false;
		if(c.gameObject.name == "Target"){
			hookedOn = true;
			var joint = gameObject.AddComponent<HingeJoint>();
        	joint.connectedBody = c.rigidbody;
			joint.breakForce = 3;
		}
	}
	
	void OnCollisionExit () {
		onPlat = false;
		hookedOn = false;
		if(!onLadder){
			fallWait = true;
			inAir = true;
		rigidbody.useGravity = false;
		}
		
	}
}


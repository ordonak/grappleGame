using UnityEngine;
using System.Collections;

public class CONTROL : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	 public int speed = 12;
	
	public Vector3 velocity = new Vector3(0,0,0);
	
	// Update is called once per frame
	void Update () {
		
		float translation = Input.GetAxis("Horizontal") * speed;
		translation *= Time.deltaTime;
	velocity = new Vector3(0,0,translation);
			rigidbody.AddForce(velocity, ForceMode.VelocityChange);
		
		        if (Input.GetButtonDown("Fire1")) {
	
		
    RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if (Physics.Raycast(ray, out hit) && hit.transform.name=="Map"){
      //this.transform.position = hit.point;// contains the point where the ray hits the
	// object named "Map"
		Vector3 tmepVec = hit.point-this.transform.position;
			rigidbody.AddForce(tmepVec, ForceMode.VelocityChange);	
 	//rigidbody.useGravity = false;
}
        }
		
		


	
	}
}

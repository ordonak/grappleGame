using UnityEngine;
using System.Collections;

public class CharMoter : MonoBehaviour {
    public float speed = 6.0F;
    public float jumpSpeed = 12.0F;
    public float gravity = 10.0F;
	public bool onPlat;
	public bool hooking;
	public bool hooked;
	public bool onLadder;
	
    private Vector3 moveDirection = Vector3.zero;
    void Update() {
        
		CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded) {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"),  Input.GetAxis("Vertical"),0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
		
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
		
		if(onLadder && Input.GetButton ("Vertical"))
		{
			gravity = 0;
			if(Input.GetAxis ("Vertical") > 0)
				this.transform.Translate((Vector3.up * Time.deltaTime)*2, Space.World);
			else
				this.transform.Translate((Vector3.down * Time.deltaTime)*2, Space.World);
		}
		
		
		
		checkClick ();
		checkHook();
		
	}
	
	public Vector3 returnMove()
	{
		return moveDirection;	
	}
	
	void checkHook()
	{
		if(hooking)
			gravity = 0;
	}
	
	void checkClick()
	{
		if(Input.GetButton ("Fire1")){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if(Physics.Raycast(ray, out hit) && hit.collider.name == "Target"){
				hooking = true;
				print ("Hit!");
				moveDirection =  hit.point- this.transform.position;
				moveDirection.z = this.transform.position.z;
				this.transform.Translate(moveDirection*Time.deltaTime);
				}
    	}
	}
	
	
	void OnCollisionEnter(Collider c)
	{
		gravity = 10;
		if(c.gameObject.name == "Target"){
			hooking = false;
			hooked = true;
			
			var joint = gameObject.AddComponent<HingeJoint>();
        	joint.connectedBody = c.rigidbody;
			joint.breakForce = 3;
		}
	}
			
	void onCollisionExit()
	{
	}
}
		
	
	

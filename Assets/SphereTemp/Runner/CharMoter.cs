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
	public bool falling = true;
	private string connectedTo;
    private Vector3 moveDirection = Vector3.zero;
    void Update() {
        
		  
		CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded && !hooked) {
			
            moveDirection = new Vector3(Input.GetAxis("Horizontal"),  Input.GetAxis("Vertical"),0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump")){
                moveDirection.y = jumpSpeed;
				
			}
        }else if(hooking)
		{
			
		}
		else if(hooked){
			
			
				
				moveDirection = new Vector3(0,0,0);
			
		}
		else{
        moveDirection.y -= gravity * Time.deltaTime;
       
		}
		
		
		checkLadder ();
		checkClick ();
		checkHook();
		 controller.Move(moveDirection * Time.deltaTime);
		
	}
	
	public Vector3 returnMove()
	{
		return moveDirection;	
	}
	
	void checkLadder()
	{
		if(onLadder && Input.GetButton ("Vertical"))
		{
			gravity = 0;
			if(Input.GetAxis ("Vertical") > 0)
				this.transform.Translate((Vector3.up * Time.deltaTime)*2, Space.World);
			else
				this.transform.Translate((Vector3.down * Time.deltaTime)*2, Space.World);
		}
	}
	
	void checkHook()
	{
		//if(hooking)
		//	gravity = 0;
	}
	
	void checkClick()
	{
		if(Input.GetButton ("Fire1")){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if(Physics.Raycast(ray, out hit) && hit.collider.tag == "Target" && connectedTo != hit.collider.name){
				hooking = true;
				print ("Hit!");
				connectedTo = hit.collider.name;
				moveDirection =  hit.point- this.transform.position;
				moveDirection.z = this.transform.position.z;
				this.transform.Translate(moveDirection*Time.deltaTime);
				}
    	}
	}
	
	
	void OnCollisionEnter(Collision c)
	{
			hooking = false;
			if(c.gameObject.tag == "Target"){
			hooking = false;
			hooked = true;
			
			//var joint = gameObject.AddComponent<HingeJoint>();
        	//joint.connectedBody = c.rigidbody;
			//joint.breakForce = 5;
			moveDirection =  new Vector3(0,0,0);
		}
		
	
	}
	
	void OnControllerColliderHit(ControllerColliderHit hit) {
       GameObject body = hit.gameObject;
		
        if (body.tag== "Target"){


			hooking = false;
			hooked = true;
			
			//var joint = gameObject.AddComponent<HingeJoint>();
        	//joint.connectedBody = c.rigidbody;
			//joint.breakForce = 5;
			moveDirection =  new Vector3(0,0,0);
		
		
		}
           
        
       
      //  body.velocity = pushDir * pushPower;
    }
			
	void onCollisionExit()
	{
		
	}
	
}
		
	
	

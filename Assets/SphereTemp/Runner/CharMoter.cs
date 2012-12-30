using UnityEngine;
using System.Collections;

public class CharMoter : MonoBehaviour {
    public float speed = 6.0F;
    public float jumpSpeed = 12.0F;
    public float gravity = 10.0F;
	public enum STATE {GROUNDED, FALLING , HOOKING, ON_LADDER, STUCK};
	public STATE state = STATE.FALLING;
	private string connectedTo;
    private Vector3 moveDirection = Vector3.zero;
	private string lastStuck;

	void CheckStuckInput ()
	{
		 if (Input.GetButton("Jump"))
			{
				state = STATE.FALLING;
                moveDirection.y = jumpSpeed;
			}
	}


	
    void Update() {
        
		  
		CharacterController controller = GetComponent<CharacterController>();
        //moveDirection = new Vector3(0,0,0);
		checkHookInput();
		switch (state)
		{
		case STATE.GROUNDED:
			
			CheckGroundInput();
			
			break;
				
		case STATE.FALLING:
			moveDirection.y -= gravity * Time.deltaTime;
			break;
		case STATE.HOOKING:
			break;
		case STATE.ON_LADDER:
			break;
		case STATE.STUCK:
			moveDirection =  new Vector3(0,0,0);
			CheckStuckInput();
			break;
		}
		lastStuck = "";
		
		
		
		//Make the move for the update
		controller.Move(moveDirection * Time.deltaTime);
	//	else if(hooked){
			
			
				
	//			moveDirection = new Vector3(0,0,0);
			
		//}
	
		
		
		//checkLadder ();
		
		//checkHook();
	
		
	}
	
	public Vector3 returnMove()
	{
		return moveDirection;	
	}
	
		void CheckGroundInput ()
	{
		
		moveDirection = new Vector3(Input.GetAxis("Horizontal"),  0,0);
            moveDirection += transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
			{
				state = STATE.FALLING;
                moveDirection.y = jumpSpeed;
			}
	}
	
	

	
	void checkHookInput()
	{
		if(Input.GetButton ("Fire1")){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if(Physics.Raycast(ray, out hit) && hit.collider.tag == "Target" ){
				state = STATE.HOOKING;
				print ("Hit!");
				
				moveDirection =  hit.point- this.transform.position;
				moveDirection.z = this.transform.position.z;
				this.transform.Translate(moveDirection*Time.deltaTime);
				}
    	}
	}
	

	
	void OnControllerColliderHit(ControllerColliderHit hit) {
       GameObject body = hit.gameObject;
		
					
		switch (body.tag){
			case "Target":

				//hooked = true;
				
			if(lastStuck!=body.name)
				state = STATE.STUCK;
			lastStuck = body.name;
				
				break;
			case "Platform":
				state = STATE.GROUNDED;
				break;
		}
           
        
       
      //  body.velocity = pushDir * pushPower;
    }
			
	void onCollisionExit()
	{
		
	}
	
}
		
	
	

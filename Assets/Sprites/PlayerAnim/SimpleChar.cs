using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleChar: MonoBehaviour {


	public CharacterController myController;
	Coroutine currentState;

	public float speed=3f;
	public float aerialspeed= 2f;
	public float gravityStr=5f;
	public float jumpSpeed=10f;
	public bool canjump=false;
	public Transform camerarotation;
	public float verticalvelocity;
	public Vector3 velocity;
	public Vector3 groundedvelocity;
	public Vector3 normal;
	public bool onWall=false;
	Animator anim;
	public bool cantmovehorizontal;
	public bool cantmovevertical;
	public int facing;
	//2down/1up/4right/3left


		public float maxJumpHeight = 1;
	public float minJumpHeight = 1;
	public float timeToJumpApex = .4f;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;
		float gravity;
	float maxJumpVelocity;
	float minJumpVelocity;






	//tentativa de pulo com aceleracao

		public float keyJumpcooldown;
		public bool jumping;
		public bool falling;


	
	



	// Use this for initialization
	void Start () {

		 anim = GetComponent<Animator>();
		maxJumpVelocity = Mathf.Abs(gravityStr) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravityStr) * minJumpHeight);
		

	}
	
	// Update is called once per frame
	void Update () 
	{

		Vector3 myVector = new Vector3(0,0,0);


		Vector3 input = Vector3.zero;
		
	
		myVector = Vector3.ClampMagnitude(input,1f);



		   if (Input.GetKey(KeyCode.S) && cantmovevertical==false)
		   { 
			   input.z=Input.GetAxis("Vertical"); cantmovehorizontal=true;
			   facing=2;

			   }

		   else if (Input.GetKey(KeyCode.W) && cantmovevertical==false)
		   { 
			   input.z=Input.GetAxis("Vertical"); cantmovehorizontal=true;facing=1;
			   }

		   else{cantmovehorizontal=false;}
		
		   


		    if (Input.GetKey(KeyCode.D) && cantmovehorizontal==false)
			{input.x=Input.GetAxis("Horizontal");cantmovevertical=true;facing=4;}
			
			else if (Input.GetKey(KeyCode.A) && cantmovehorizontal==false)
			{input.x=Input.GetAxis("Horizontal");cantmovevertical=true;facing=3;}
			else{cantmovevertical=false;}


		


		if(myController.isGrounded)
		{
	
			myVector=input;
			Quaternion inputRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(camerarotation.forward,Vector3.up),Vector3.up);
			myVector = inputRotation * myVector;
			myVector *=speed;
			canjump=true;


		}

		else
		{

			myVector=groundedvelocity;
			myVector+=input*aerialspeed;
			canjump=false;

		}


			myVector = Vector3.ClampMagnitude(myVector,speed);
			myVector= myVector  * Time.deltaTime;
			verticalvelocity= verticalvelocity - gravityStr*Time.deltaTime;
	

			
			




		
		myVector.y = verticalvelocity*Time.deltaTime;

		CollisionFlags flags= myController.Move(myVector);
		velocity= myVector / Time.deltaTime;


		if((flags & CollisionFlags.Below) !=0)
		{

			//essevalor ta zuando opulo
		//groundedvelocity =Vector3.ProjectOnPlane(velocity,Vector3.up);
		
		canjump=true;
		verticalvelocity=-3f;
		onWall=false;
		jumping=false;


		}
		else if((flags & CollisionFlags.Sides) !=0)
		{
			canjump=true;
			onWall =true;



		}
		else 
		{
		canjump=false;
		onWall=false;
		}


		


			   if (Input.GetKey(KeyCode.W)){ anim.SetBool("UP",true);  }
			      if (!Input.GetKey(KeyCode.W)){ anim.SetBool("UP",false);  }

				     if (Input.GetKey(KeyCode.S)){ anim.SetBool("DOWN",true);  }
					 if (!Input.GetKey(KeyCode.S)){ anim.SetBool("DOWN",false);  }

					 

			   if (Input.GetKey(KeyCode.D)){ anim.SetBool("RIGHT",true);  }
			      if (!Input.GetKey(KeyCode.D)){ anim.SetBool("RIGHT",false);  }

				     if (Input.GetKey(KeyCode.A)){ anim.SetBool("LEFT",true);  }
					 if (!Input.GetKey(KeyCode.A)){ anim.SetBool("LEFT",false);  }





		
	}

	


	

		
			void OnControllerColliderHit(ControllerColliderHit hit)
			{
				normal = hit.normal;

				
				




			}






}

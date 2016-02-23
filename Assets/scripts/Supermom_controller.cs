using UnityEngine;
using System.Collections;

public class Supermom_controller : MonoBehaviour {
		//Prepare variables
		
		
		public float maxspeed=50f; 	//Running maximum Velocity
		public float runspeed=120f;	
		public bool facingright=true;	//to flip the character left and right	
		public Rigidbody2D myrigid;		//Rigidbody2D variable	
		public Transform transform;		//Transform Variable
		public Animator anim;			//Animator Component Variable	
		public bool grounded=false;		//Used for checking the ground
		public Transform groundcheck;	//This too
		public float groundradius=0.2f;	//Ground Check Radius
		public LayerMask isGround;		//Layer mask to specify what is ground in the game scene
		public float jumpforce=400f;	//Force with which the player should jump
		public bool candoublejump;		//variable to check if player can jump or not
		
		void Start()
		{
			myrigid = GetComponent<Rigidbody2D> ();
			anim = GetComponent<Animator> ();
			transform = GetComponent<Transform> ();
			
		}
		
		
		
		
		void FixedUpdate () {
			grounded = Physics2D.OverlapCircle (groundcheck.position,groundradius,isGround);
			anim.SetFloat ("vspeed",myrigid.velocity.y);
			anim.SetBool ("ground",grounded);
			
			
			//Jumping 
			if (Input.GetKeyDown (KeyCode.Space) ) {
				if(grounded)
				{
					myrigid.AddForce (new Vector2 (0, jumpforce));
					grounded=false;
					candoublejump=true;
				}
				//double Jumping
				else{
					if(candoublejump)
					{
						candoublejump=false;
						myrigid.velocity=new Vector2(myrigid.velocity.x,0);
						myrigid.AddForce(new Vector2(0,jumpforce));
					}
				}
				
			}
			
			
			
			//moving player left and right
			float move = Input.GetAxis ("Horizontal");
			myrigid.velocity = new Vector2 (move * maxspeed, myrigid.velocity.y);
			anim.SetFloat("speed",Mathf.Abs(move));

			if (move > 0 && !facingright)
				flip ();
			if (move < 0 && facingright)
				flip ();
			
			
		}
		
		
		
		//fliping
		void flip()
		{
			facingright=!facingright;
			
			Vector2 thescale=transform.localScale;
			thescale.x *=-1;
			transform.localScale=thescale;
		}
		
		void Update()
		{
		}
		
		
	}

using UnityEngine;
using System.Collections;

public enum PlayerWeaponType{KNIFE,PISTOL,NULL}

public class PlayerController : MonoBehaviour {
	
	//General
	public GameObject Player; 
	float dodgeTimer;
	bool dodging = false;
	float moveSpeed; 
	float moveDirection;

	//Movement
	public Animator animator;
	public float runSpeed=10.0f;

	public float dodgeDistance=50.0f;
	public float dodgeTime = 0.4f;

	//Combat
	public Rigidbody myRigidBody;
	//public Transform hitTestPivot,gunPivot;
	public GameObject mousePointer,proyectilePrefab;
	float attackTime = 0.4f;


	int hashSpeed;
	float cooldownTimer;


	void Start () 
	{
		//SetWeapon (PlayerWeaponType.PISTOL);
		myRigidBody = GetComponent<Rigidbody> ();
		hashSpeed = Animator.StringToHash ("Speed");
		//attackTimer.StartTimer (0.1f);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		cooldownTimer = Mathf.Max (0f, cooldownTimer - Time.deltaTime);
			
		animator.SetFloat (hashSpeed, myRigidBody.velocity .magnitude);

		float inputHorizontal = Input.GetAxis ("Horizontal");
		float inputVertical = Input.GetAxis ("Vertical");

		if (!dodging && cooldownTimer == 0 && Input.GetKeyDown (KeyCode.Space)) 
		{
			print ("Dodged!");
			dodging = true;
			dodgeTimer = dodgeTime;
		
		}

		if(dodging && dodgeTimer != 0)
		{
			dodgeTimer = Mathf.Max (0f, dodgeTimer - Time.deltaTime);
	
			Vector3 newVelocity=new Vector3(inputVertical*dodgeDistance, 0.0f, inputHorizontal*-dodgeDistance);
			myRigidBody.velocity = newVelocity;

		} 

		if(!dodging)
		{
			Vector3 newVelocity=new Vector3(inputVertical*runSpeed, 0.0f, inputHorizontal*-runSpeed);
			myRigidBody.velocity = newVelocity;
		}

		if (dodgeTimer == 0) 
		{
			dodging = false;
		}

		UpdateAim ();
	
	}

	void UpdateAim()
	{


		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousePos.y = transform.position.y;
		mousePointer.transform.position = mousePos;
		float deltaY = mousePos.z - transform.position.z;
		float deltaX = mousePos.x - transform.position.x;
		float angleInDegrees = Mathf.Atan2 (deltaY, deltaX) * 180 / Mathf.PI;
		transform.eulerAngles = new Vector3 (0, -angleInDegrees, 0);
	}
}

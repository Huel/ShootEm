using UnityEngine;
using System.Collections;

public enum PlayerWeaponType{KNIFE,PISTOL,NULL}

public class PlayerController : MonoBehaviour {

	//Movement
	public float moveSpeed=10.0f;
	public Animator animator;
	//Combat
	public Rigidbody myRigidBody;
	//public Transform hitTestPivot,gunPivot;
	public GameObject mousePointer,proyectilePrefab;



	int hashSpeed;
	float attackTime = 0.4f;

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
		animator.SetFloat (hashSpeed, myRigidBody.velocity .magnitude);

		float inputHorizontal = Input.GetAxis ("Horizontal");
		float inputVertical = Input.GetAxis ("Vertical");

		Vector3 newVelocity=new Vector3(inputVertical*moveSpeed, 0.0f, inputHorizontal*-moveSpeed);
		myRigidBody.velocity = newVelocity;

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

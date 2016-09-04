using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform trackedObject,trackedObjectZoom,targetCamera;
	Vector3 offset;
	static CameraController myslf;
	Transform currentTrackedObject;

	void Awake()
	{
		myslf = this;
	}

	// Use this for initialization
	void Start () 
	{
		currentTrackedObject = trackedObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		targetCamera.position = Vector3.Lerp (targetCamera.position, currentTrackedObject.position, 0.08f)+offset;

		if (Input.GetKeyDown (KeyCode.LeftShift)) 
		{
			currentTrackedObject=trackedObjectZoom;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) 
		{
			currentTrackedObject=trackedObject;
		}
	
	}
}

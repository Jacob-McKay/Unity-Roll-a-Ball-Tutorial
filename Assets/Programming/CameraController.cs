using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		//get the vector3 representing the difference between the camera and player transforms
		//as they are positioned in the scene at runtime
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//we use lateUpdate to be sure that we're in the right spot after the player has moved
		transform.position = player.transform.position + offset;
	}
}

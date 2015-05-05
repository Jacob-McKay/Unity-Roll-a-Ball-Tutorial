using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	
	private Rigidbody rb;
	private int count;
	private int maxPickups;
	private GameObject[] pickups;

	public Text countText;
	public Text winText;
	
	void Start ()
	{
		//this gets the rigid body of the attached gameobject which happens to be our ball,
		//that we created this script as a component of
		rb = GetComponent<Rigidbody> ();
		count = 0;
		pickups = GameObject.FindGameObjectsWithTag ("Pickup");
		maxPickups = pickups.Length;
		winText.text = "";
		updateCounter ();
	}
	
	void FixedUpdate ()
	{
		//not in Update() because this is physics crap

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rb.AddForce (movement * speed);
	}

	//collect pickup objects	
	void OnTriggerEnter (Collider other) 
	{
		//get handle to game object because we will operate on it
		GameObject go = other.gameObject;

		//if it's a pickup object we're gonna do stuff
		if(go.CompareTag("Pickup")){

			//don't destroy just deactivate.
			go.SetActive(false);
			//Destroy(other.gameObject);

			//you get a point buddy!
			count++;
			updateCounter ();
		}
	}

	//convenience method to update the "score" or counter text in the UI
	//detects for win condition and displays win message accordingly
	void updateCounter ()
	{
		countText.text = "Count: " + count.ToString ();

		if (count >= maxPickups) {
			updateWinText (true);
		}
	}

	void updateWinText(bool didWin){
		winText.text = didWin ? "You won Brah!! You haz all da balls: " + count + "!!!" : "You just plain and simply suck... Sorry Brah!";
	}
}
using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		//transform rotation is set to 45, 45, 45 in the scene by us
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}

using UnityEngine;
using System.Collections;

public class PlatformColliderActivation : MonoBehaviour {

	public GameObject groundCheck;
	BoxCollider2D myCollider;

	// Use this for initialization
	void Start () {
		myCollider = GetComponent<BoxCollider2D> ();
		myCollider.enabled = false;
		if(groundCheck.transform.position.y > this.transform.position.y){
			myCollider.enabled = true;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (groundCheck.transform.position.y > this.transform.position.y) {
			myCollider.enabled = true;
		} else {
			myCollider.enabled = false;
		}
	}
}

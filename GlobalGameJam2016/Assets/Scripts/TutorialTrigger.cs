using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialTrigger : MonoBehaviour {

	public GameObject textBubble;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		textBubble.transform.position = gameObject.transform.position + new Vector3(-5f, 5f, 0f);
	}


	void OnTriggerStay2D(Collider2D coll){
		if (coll.tag == "Player") {
			textBubble.SetActive (true);
		}
	}
	void OnTriggerExit2D(Collider2D coll){
		if (coll.tag == "Player") {
			textBubble.SetActive (false);
		}
	}

}

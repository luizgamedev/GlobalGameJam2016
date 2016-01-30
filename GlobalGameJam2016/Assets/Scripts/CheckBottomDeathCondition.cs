using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CheckBottomDeathCondition : MonoBehaviour {

	public Text CallbackText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			//CallbackText.text = "Dead!";
			coll.gameObject.SetActive (false);
			//Camera.main.gameObject.SetActive (false);
		}
	}
}

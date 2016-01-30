using UnityEngine;
using System.Collections;

public class EndGameTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.tag == "Player"){
			Application.LoadLevel (Application.loadedLevel + 1);
		}
	}
}

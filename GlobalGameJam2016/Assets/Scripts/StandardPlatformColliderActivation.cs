using UnityEngine;
using System.Collections;

public class StandardPlatformColliderActivation : MonoBehaviour {

	GameObject groundCheck;
	GameObject player;
	BoxCollider2D[] myColliders;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		groundCheck = player.transform.Find("GroundCheck").gameObject;
		if(!groundCheck){
			Debug.Log ("StandardPlatformColliderActivation -- No Ground Check!");
		}

		myColliders = GetComponentsInChildren<BoxCollider2D> ();

		if(groundCheck.transform.position.y > this.transform.position.y){
			SetLayerRecursively(gameObject, 11);
		}

	}

	// Update is called once per frame
	void Update () {
		if (groundCheck.transform.position.y > this.transform.position.y) {
			SetLayerRecursively(gameObject, 11);
			//collider.enabled = true;
		} else {
			SetLayerRecursively(gameObject, 10);
			//collider.enabled = false;
		}
	}

	void SetLayerRecursively(GameObject gameObj, int newLayer){
		gameObj.layer = newLayer;
		foreach( Transform child in gameObj.transform ){
			SetLayerRecursively(child.gameObject, newLayer);
		}
	}

}

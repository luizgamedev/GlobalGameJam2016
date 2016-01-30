using UnityEngine;
using System.Collections;

public class FollowPlayerCameraBehaviour : MonoBehaviour {

	GameObject playerToFollow;

	// Use this for initialization
	void Start () {
		playerToFollow = GameObject.FindGameObjectWithTag ("Player");
		if(!playerToFollow){
			Debug.Log("FollowPlayerCameraBehaviour:: Error! No Player Found!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerpos = playerToFollow.transform.position;

		this.transform.position = new Vector3 (playerpos.x, this.transform.position.y, this.transform.position.z);
	}
}

using UnityEngine;
using System.Collections;

public class BottomUpCameraMovement : MonoBehaviour {

	public float UpSpeed;
	GameObject player;

	// Use this for initialization
	void Start () {
		UpSpeed = 0.5f;
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (player.activeInHierarchy) {
			transform.Translate (new Vector3 (0f, UpSpeed * Time.deltaTime));
		}
	}
}

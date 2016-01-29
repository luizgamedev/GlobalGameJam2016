using UnityEngine;
using System.Collections;

public class BottomUpCameraMovement : MonoBehaviour {

	public float UpSpeed;

	// Use this for initialization
	void Start () {
		UpSpeed = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate ( new Vector3(0f, UpSpeed * Time.deltaTime) );
	}
}

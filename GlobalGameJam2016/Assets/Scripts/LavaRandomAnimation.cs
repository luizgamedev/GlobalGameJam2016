using UnityEngine;
using System.Collections;

public class LavaRandomAnimation : MonoBehaviour {

	public int xBound;
	public float maxVelocity;
	bool isGoingRight;
	float actualVelocity;
	float index;

	// Use this for initialization
	void Start () {
		maxVelocity = 8f;
		actualVelocity = Random.Range (0.1f, maxVelocity);
		isGoingRight = true;
		xBound = 8;
	}
	
	// Update is called once per frame
	void Update () {

		index += Time.deltaTime;

		//Change Direction
		if(transform.position.x > xBound){
			transform.position = new Vector3 (xBound, transform.position.y, transform.position.z);
			isGoingRight = false;
			actualVelocity = -Random.Range (0.1f, maxVelocity);
		}
		if(transform.position.x < -xBound){
			transform.position = new Vector3 (-xBound, transform.position.y, transform.position.z);
			isGoingRight = true;
			actualVelocity = Random.Range (0.1f, maxVelocity);
		}

//		//Randomly Change
//		if(Random.Range(0,100) < 5){
//			isGoingRight = !isGoingRight;
//			actualVelocity = -actualVelocity;
//		}

		transform.Translate (new Vector3 ( (actualVelocity * Time.deltaTime), 0.01f*Mathf.Sin(15f*index), 0f  ));
	}
}

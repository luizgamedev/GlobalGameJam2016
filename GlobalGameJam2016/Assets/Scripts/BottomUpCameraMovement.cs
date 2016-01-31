using UnityEngine;
using System.Collections;

public class BottomUpCameraMovement : MonoBehaviour {

	public float UpSpeed;
	GameObject player;

	Vector3 startposition;
	bool blockMove;

	// Use this for initialization
	void Start () {
		UpSpeed = 0.5f;
		player = GameObject.FindWithTag ("Player");
		blockMove = true;
		startposition = transform.localPosition;
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		GameEventManager.GamePause += GamePause;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.activeInHierarchy && !blockMove) {
			transform.Translate (new Vector3 (0f, UpSpeed * Time.deltaTime));
		}
	}

	void GameStart(){
		transform.localPosition = startposition;
		blockMove = false;
	}

	void GameOver(){
		blockMove = true;
	}

	void GamePause(){
		blockMove = true;
	}
}

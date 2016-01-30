using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class EnemyBehaviour : MonoBehaviour {

	public GameObject leftReferenceObject;
	public GameObject rightReferenceObject;
	public float speed = 0.1f;
	public GameObject eyeSight;
	public float eyeTimer = 3.0f;
	public float eyePulsingTimer = 0.5f;
	public float pulsingSpeed = 1f;

	EdgeCollider2D eyeSightCollider;
	bool isGoingRight = true;
	PlatformerCharacter2D platformerController;
	Vector3 rightRef;
	Vector3 leftRef;
	bool pulseSight;
	SpriteRenderer eyeSightSpriteRenderer;



	// Use this for initialization
	void Start () {
		eyeSightCollider = GetComponent<EdgeCollider2D> ();
		eyeSightCollider.enabled = false;
		eyeSight.SetActive (false);
		platformerController = GetComponent<PlatformerCharacter2D> ();
		rightRef = rightReferenceObject.transform.position;
		leftRef = leftReferenceObject.transform.position;
		InvokeRepeating ("TurnOnOffEyeKiller", eyeTimer, eyeTimer);
		pulseSight = false;
		eyeSightSpriteRenderer = eyeSight.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > rightRef.x){
			isGoingRight = false;
		}
		if(transform.position.x < leftRef.x){
			isGoingRight = true;
		}

		if (isGoingRight) {
			platformerController.Move(speed, false, false);
		} else {
			platformerController.Move(-speed, false, false);
		}
		if (pulseSight == false) {
			eyeSightSpriteRenderer.color = new Color(eyeSightSpriteRenderer.color.r, eyeSightSpriteRenderer.color.g, eyeSightSpriteRenderer.color.b, 1f);
		} else {
			eyeSightSpriteRenderer.color = new Color(eyeSightSpriteRenderer.color.r, eyeSightSpriteRenderer.color.g, eyeSightSpriteRenderer.color.b, Mathf.PingPong(Time.time * pulsingSpeed, 1f));
		}

	}

	void TurnOnOffEyeKiller(){
		eyeSight.SetActive (!eyeSightCollider.enabled);
		if (!eyeSightCollider.enabled) {
			pulseSight = true;
			Invoke ("FinishLoadingTheEye", eyePulsingTimer);
		} else {
			eyeSightCollider.enabled = false;
		}


	}

	void FinishLoadingTheEye(){
		eyeSightCollider.enabled = true;
		pulseSight = false;
	}
}
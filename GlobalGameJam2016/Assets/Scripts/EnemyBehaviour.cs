using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class EnemyBehaviour : MonoBehaviour {

	public GameObject leftReferenceObject;
	public GameObject rightReferenceObject;
	public float speed;
	public float xForce;
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
	private Rigidbody2D myRigidbody2D;



	// Use this for initialization
	void Start () {
		eyeSightCollider = GetComponent<EdgeCollider2D> ();
		eyeSightCollider.enabled = false;
		eyeSight.SetActive (false);
		//platformerController = GetComponent<PlatformerCharacter2D> ();

		rightRef = rightReferenceObject.transform.position;
		leftRef = leftReferenceObject.transform.position;
		InvokeRepeating ("TurnOnOffEyeKiller", eyeTimer, eyeTimer);
		pulseSight = false;
		eyeSightSpriteRenderer = eyeSight.GetComponent<SpriteRenderer> ();
		myRigidbody2D = GetComponent<Rigidbody2D> ();
		speed = 2f;
		xForce = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > rightRef.x){
			isGoingRight = false;
			transform.rotation = Quaternion.Euler(new Vector3(0f,180f,0f));
		}
		if(transform.position.x < leftRef.x){
			isGoingRight = true;
			transform.rotation = Quaternion.Euler(new Vector3(0f,0f,0f));
		}

		if (isGoingRight) {
			myRigidbody2D.velocity = new Vector2 (speed, 0f);
		} else {
			myRigidbody2D.velocity = new Vector2 (-speed, 0f);
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
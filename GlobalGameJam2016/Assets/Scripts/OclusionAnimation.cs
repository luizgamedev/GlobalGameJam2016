using UnityEngine;
using System.Collections;

public class OclusionAnimation : MonoBehaviour {

	Color opaqueBlack;
	Color transparentBlack;
	SpriteRenderer myRenderer;
	float FadeSpeed;
	float FadeOutSpeed;

	// Use this for initialization
	void Start () {
		opaqueBlack = Color.black;
		transparentBlack = Color.black;
		transparentBlack.a = 0f;
		myRenderer = GetComponent<SpriteRenderer> ();
		FadeSpeed = 0.01f;
		FadeOutSpeed = 0.02f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.RightControl)) {
			myRenderer.color = Color.Lerp (myRenderer.color, opaqueBlack, FadeSpeed);
		} else {
			myRenderer.color = Color.Lerp (myRenderer.color, transparentBlack, FadeOutSpeed);
		}
	}
}

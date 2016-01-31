using UnityEngine;
using System.Collections;

public class OclusionAnimation : MonoBehaviour {

	Color opaqueBlack;
	Color transparentBlack;
	SpriteRenderer myRenderer;
	public float FadeSpeed;
	public float FadeOutSpeed;

	bool stopOclusion;

	// Use this for initialization
	void Start () {
		opaqueBlack = Color.black;
		transparentBlack = Color.black;
		transparentBlack.a = 0f;
		myRenderer = GetComponent<SpriteRenderer> ();
		FadeSpeed = 0.01f;
		FadeOutSpeed = 0.02f;
		stopOclusion = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!stopOclusion) {
			if (Input.GetKey (KeyCode.LeftControl)) {
				myRenderer.color = Color.Lerp (myRenderer.color, opaqueBlack, FadeSpeed);
			} else {
				myRenderer.color = Color.Lerp (myRenderer.color, transparentBlack, FadeOutSpeed);
			}
		}
	}

	public void StartOclusion(){
		stopOclusion = false;
	}

	public void StopOclusion(){
		stopOclusion = true;
	}
}

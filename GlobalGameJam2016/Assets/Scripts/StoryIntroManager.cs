using UnityEngine;
using System.Collections;
using BitStrap;

public class StoryIntroManager : Singleton<StoryIntroManager> {

	public Sprite[] Frames;
	public GameObject BaseFrame;
	public float slideTime = 5f;
	GameObject actualFrame = null;
	private int count = 0;

	string dieState = "Die";
	string introState = "Intro";

	// Use this for initialization
	void Start () {
		CreateNewSlide ();
	}

	void Update(){
		if(Input.GetButtonDown("Jump")){
			if(actualFrame != null){
				actualFrame.GetComponent<Animator> ().SetTrigger ("TriggerOut");
			}
		}
	}



	public void TriggerFadeOff(){
		Invoke ("TriggerFade", slideTime);
	}

	public void TriggerFade(){
		actualFrame.GetComponent<Animator> ().SetTrigger ("TriggerOut");
	}

	public void CreateNewSlide(){
		if (count >= Frames.GetLength (0)) {
			Application.LoadLevel (Application.loadedLevel + 1);
			return;
		}

		if (actualFrame) {
			GameObject.Destroy (actualFrame);
		}

		if( Frames.GetLength(0) > 0 ){
			actualFrame = GameObject.Instantiate (BaseFrame) as GameObject;
			actualFrame.GetComponent<SpriteRenderer> ().sprite = Frames [count];
			count++;
		}
	}
}

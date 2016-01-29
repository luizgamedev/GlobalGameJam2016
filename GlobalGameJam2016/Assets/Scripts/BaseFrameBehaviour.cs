using UnityEngine;
using System.Collections;

public class BaseFrameBehaviour : MonoBehaviour {

	public void TriggerFade(){
		StoryIntroManager.Instance.TriggerFadeOff ();
	}

	public void Die(){
		StoryIntroManager.Instance.CreateNewSlide ();
	}
}

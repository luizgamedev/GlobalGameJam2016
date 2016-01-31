using UnityEngine;
using System.Collections;
using BitStrap;
using UnityEngine.UI;

public class LeiImageManager : Singleton<LeiImageManager> {

	public Sprite[] LeiSprites;

	int flowerState = 0;
	Image leiCanvas;

	void Start(){
		leiCanvas = gameObject.GetComponent<Image>();
		leiCanvas.sprite = LeiSprites [0];
	}


	public void AddFlowers(){
		flowerState++;
		if(flowerState < LeiSprites.GetLength(0)){
			leiCanvas.sprite = LeiSprites [flowerState];
		}
	}

	public void ResetFlowers(){
		flowerState = 0;
		leiCanvas.sprite = LeiSprites [0];
	}

}

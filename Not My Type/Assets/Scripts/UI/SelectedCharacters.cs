using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectedCharacters : MonoBehaviour {

	public Sprite seletedImage;
	private Sprite normalImage;
	// Use this for initialization
	void Awake () {
		normalImage = gameObject.GetComponent<Image>().sprite;

		if(GetComponent<Toggle>().isOn) {
			GetComponent<Image>().sprite = seletedImage;
		}
		gameObject.GetComponent<Toggle>().onValueChanged.AddListener((selected) => {

			if (selected) {
				gameObject.GetComponent<Image>().sprite = seletedImage;
			} else {
				gameObject.GetComponent<Image>().sprite = normalImage;
			}
		} ); 
	}
}

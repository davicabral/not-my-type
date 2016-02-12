using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectAnswer : MonoBehaviour {

	private Color idleColor = new Color(246f/255f,242/255f,228/255f);
	private Color selectedColor = new Color(249f/255f,207/255f,55/255f);

	// Use this for initialization
	void Start () {
		GetComponent<Image>().color = idleColor;
		gameObject.GetComponent<Toggle>().onValueChanged.AddListener((selected) => {

			if (selected) {
				gameObject.GetComponent<Image>().color = selectedColor;
			} else {
				gameObject.GetComponent<Image>().color = idleColor;
			}
		} ); 
	}

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectAnswerMode : MonoBehaviour {

	public GameObject answerMode;
	void Awake () {
		
		answerMode.SetActive(GetComponent<Toggle>().isOn);

		gameObject.GetComponent<Toggle>().onValueChanged.AddListener((selected) => {
			answerMode.SetActive(selected);
		} ); 
	}
}

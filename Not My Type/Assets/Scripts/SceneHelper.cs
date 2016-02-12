using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneHelper : MonoBehaviour {

	public void GoToScene(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}
}

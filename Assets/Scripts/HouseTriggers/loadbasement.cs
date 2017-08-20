using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadbasement : MonoBehaviour {

	 loadFade fadeScr;
	// Use this for initialization
	void Start () {
		//fadeScr = GameObject.FindObjectOfType<loadFade>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			SceneManager.LoadSceneAsync (2);
			//fadeScr.EndScene(2);
		}
	}
}

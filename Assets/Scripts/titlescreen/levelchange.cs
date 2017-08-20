using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class levelchange : MonoBehaviour {

	loadFade fadeScr;
	//public int scene;
	//AdManager admgr;

	void Awake()
	{
		

		//admgr = GameObject.FindObjectOfType<AdManager>();
		//StartCoroutine (displayAd ());
		//PlayerSettings.virtualRealitySupported = true;
	}
	void Start()
	{
		fadeScr = GameObject.FindObjectOfType<loadFade>();
	}

	public void changeLevel(int scenenum)
	{
		fadeScr.EndScene(scenenum);
		//SceneManager.LoadSceneAsync(scenenum);
	}

	//IEnumerator displayAd()
	//{
	//	yield return new WaitForSeconds (2);
		//admgr.GameOver ();
	//}
}
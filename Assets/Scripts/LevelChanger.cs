using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

	ScreenFader fadeScr;
	public int SceneNumb;

	void Awake()
	{
		//fadeScr = GameObject.FindObjectOfType<ScreenFader>();
	}

	public void changeLevel()
	{
		
		//fadeScr.EndScene(SceneNumb);
		SceneManager.LoadSceneAsync(SceneNumb);
	}
}
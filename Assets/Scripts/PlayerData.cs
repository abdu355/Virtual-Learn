using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
	public GameObject l1,l2,l3,l4,tips;
	public Text tiptxt;
	// Use this for initialization
	void Awake ()
	{
		int mode = PlayerPrefs.GetInt ("mode");
		switch (mode) {
		case 1: //joystick
//			GameObject[] obj = GameObject.FindGameObjectsWithTag ("motion");
//			for (int i = 0; i < obj.Length; i++) {
//				obj [i].SetActive (false);
//			}
			l1.SetActive (false);
			l2.SetActive (false);
			l3.SetActive (false);
			l4.SetActive (false);
			if (tiptxt != null)
				tiptxt.text = "- A to jump \n - C to pickup objects \n - D to run";
			GameObject[] obj2 = GameObject.FindGameObjectsWithTag ("key");
			for (int i = 0; i < obj2.Length; i++) {
				obj2 [i].GetComponent<Gazepickup>().enabled = false;
				obj2 [i].GetComponent<Teleport>().enabled = true;
			}
			break;
		case 2: //gazeinput
			//GameObject[] obj3 = GameObject.FindGameObjectsWithTag ("motion");
			//for (int i = 0; i < obj3.Length; i++) {
			//	obj3 [i].SetActive (true);
			//}
			l1.SetActive(true);
			l2.SetActive(true);
			l3.SetActive(true);
			l4.SetActive(true);
			//if(tips!=null)
			//	tips.SetActive (true);
			if (tiptxt != null)
				tiptxt.text = "- Look down to move\n - Gaze to pickup objects";
			GameObject[] obj4 = GameObject.FindGameObjectsWithTag ("key");
			for (int i = 0; i < obj4.Length; i++) {
				obj4 [i].GetComponent<Gazepickup>().enabled = true;
				obj4 [i].GetComponent<Teleport>().enabled = false;
			}
			break;
		
		default:
			break;

		}
	}
	void Start()
	{
		StartCoroutine (removeTips ());
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	IEnumerator removeTips(){
		yield return new WaitForSeconds (4);
		if (tips != null) {
			tips.SetActive (false);
		}
	}
}

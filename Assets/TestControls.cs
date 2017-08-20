using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestControls : MonoBehaviour {
	public Text txtbox;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			Debug.Log (Input.inputString);
			txtbox.text = Input.inputString;

		}
		
	}


}

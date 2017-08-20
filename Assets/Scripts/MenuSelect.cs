// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour, IGvrGazeResponder
{
	private float waitTime = 0f;
	private bool isGazedAt;
	public float targetTime = 300f;
	private GameObject reticle;

	public Text t1, t2;

	public float waittillLoadTime = 3f;
	private int mode = -1;

	private IEnumerator routine;
	levelchange scrnfader;

	void Start ()
	{
		SetGazedAt (false);
		reticle = GameObject.FindWithTag ("Reticle");
		routine = startlevelinMode (-1);
		scrnfader = GameObject.FindObjectOfType<levelchange> ();
	}

	void LateUpdate ()
	{
		GvrViewer.Instance.UpdateState ();
		if (GvrViewer.Instance.BackButtonPressed) {
			Application.Quit ();
		}
	}

	void Update () //Gaze to Select ------------------------
	{
		if (isGazedAt) {
			waitTime++;
			if (waitTime >= targetTime) {
				reticle.GetComponent<Renderer> ().material.SetColor ("_Color", Color.magenta);
				if (t1 != null && t2 != null) {
					t1.text = tag + " selected";
					t2.text = tag + " selected";
				}
				//Debug.Log ("Controller Mode: " + tag);
				StartCoroutine (routine);

			}

		}
	
	}

	public void SetGazedAt (bool gazedAt)
	{
		Debug.Log ("Item: " + name + " gazed at ? " + gazedAt);
		isGazedAt = gazedAt;
		if (name == "JoystickBtn") {
			mode = 1;
			routine = startlevelinMode (mode);
			PlayerPrefs.SetInt ("mode", 1);
		} else if (name == "GazeControlBtn") {
			mode = 2;		
			routine = startlevelinMode (mode);
			PlayerPrefs.SetInt ("mode", 2);
		} else if (name == "Credits") {
			mode = 3;		
			routine = startlevelinMode (mode);
			PlayerPrefs.SetInt ("mode", 3);
		} else {
			mode = 4;		
			routine = startlevelinMode (mode);
			PlayerPrefs.SetInt ("mode", 4);
		}
		return;
	}


	#region IGvrGazeResponder implementation

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see GvrGaze).
	public void OnGazeEnter ()
	{
		waitTime = 0f;
		SetGazedAt (true);
		if (reticle != null)
			reticle.GetComponent<Renderer> ().material.SetColor ("_Color", Color.green);
	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit ()
	{
		waitTime = 0f;
		SetGazedAt (false);
		if (reticle != null)
			reticle.GetComponent<Renderer> ().material.SetColor ("_Color", Color.white);
		StopCoroutine (routine);
	}

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnPointerExit.
	public void OnGazeTrigger ()
	{
		
	}

	#endregion

	IEnumerator startlevelinMode (int mode)
	{
		yield return new WaitForSeconds (waittillLoadTime);
		switch (mode) {
		case 1: 
			Debug.Log ("levelstarted in joystick mode");
			//SceneManager.LoadSceneAsync (1);
			scrnfader.changeLevel(2);
			break;

		case 2: 
			Debug.Log ("levelstarted in gaze mode");
			//SceneManager.LoadSceneAsync (1);
			scrnfader.changeLevel(2);
			break;
		case 3:
			scrnfader.changeLevel (4);
			break;
		default:
			Debug.Log ("no mode selected");
			scrnfader.changeLevel (1);
			break;
		}


	}
}

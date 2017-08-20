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

[RequireComponent (typeof(Collider))]
public class Gazepickup : MonoBehaviour, IGvrGazeResponder
{
	private Vector3 startingPosition;

	public Material inactiveMaterial;
	public Material gazedAtMaterial;
	private bool gazedAtOb;
	private float waitTime = 0f;

	public float gazewaitTime = 10f;

	public GameObject player;
	public GameObject cam;
	private GameObject reticle;
	public KeyCode pickupKey;


	private Ray ray;
	bool carrying;
	GameObject carriedObject;
	public float distance = 3f;
	public float smooth = 5f;

	public GameObject pickupsound;

	void Start ()
	{
		reticle = GameObject.FindWithTag("Reticle");
		cam = GameObject.FindWithTag ("MainCamera");
		startingPosition = transform.localPosition;
		SetGazedAt (false);
	}

	void LateUpdate ()
	{
		GvrViewer.Instance.UpdateState ();
		if (GvrViewer.Instance.BackButtonPressed) {
			Application.Quit ();
		}
	}

	void Update() //Gaze to Pickup ------------------------
	{
		reticle = GameObject.FindWithTag("Reticle");
		if (carrying) {
			carry (carriedObject);
			checkDrop ();
		}
		else if (gazedAtOb) {
			waitTime++;

			if (waitTime >= gazewaitTime) {
				reticle.GetComponent<Renderer> ().material.SetColor ("_Color", Color.magenta);
				ray = reticle.GetComponent<PickupObject> ().getRay ();
				//ray = new Ray(reticle.transform.position, reticle.transform.forward);
				Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

				RaycastHit hit;
				if(Physics.Raycast(ray, out hit)) {
					//Debug.DrawLine (transform.position, hit.point, Color.red);
					Pickupable p = hit.collider.GetComponent<Pickupable>();
					if(p != null) {
						Debug.Log ("carrying");
						pickupsound.SetActive (true);
						carrying = true;
						carriedObject = p.gameObject;
						//p.gameObject.rigidbody.isKinematic = true;
						p.gameObject.GetComponent<Rigidbody>().useGravity = false;
					}
				}
			}
		}
	}
	void checkDrop() {
		if(Input.GetButtonDown("C")) {
			dropObject();
		}
	}

	public void dropObject() {
		carrying = false;
		//carriedObject.gameObject.rigidbody.isKinematic = false;
		carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
		carriedObject = null;
	}
	void carry(GameObject o) {
		o.transform.position = Vector3.Lerp (o.transform.position, cam.transform.position + cam.transform.forward * distance, Time.deltaTime * smooth);
		//o.transform.position = ray.GetPoint(distance);
		o.transform.rotation = Quaternion.identity;
	}

	public void SetGazedAt (bool gazedAt)
	{
		gazedAtOb = gazedAt;
		if (inactiveMaterial != null && gazedAtMaterial != null) {
			GetComponent<Renderer> ().material = gazedAt ? gazedAtMaterial : inactiveMaterial;
			return;
		}
		GetComponent<Renderer> ().material.color = gazedAt ? Color.green : Color.red;
	}

	public void Reset ()
	{
		transform.localPosition = startingPosition;
	}

	public void TeleportRandomly ()
	{
		Vector3 direction = Random.onUnitSphere;
		direction.y = Mathf.Clamp (direction.y, 0.5f, 1f);
		float distance = 2 * Random.value + 1.5f;
		transform.localPosition = direction * distance;

	}

	//public void pickUp ()
	//{

	//	GetComponent<Rigidbody> ().isKinematic = true;
	//	transform.parent = player.transform;
	//	transform.position = new Vector3 (reticle.transform.position.x - 1f, reticle.transform.position.y, reticle.transform.position.z - 1.5f);

	//
	//}
	private void changecolor(Color color)
	{
		if(reticle!=null)
			reticle.GetComponent<Renderer> ().material.SetColor ("_Color", color);
	}

	#region IGvrGazeResponder implementation

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see GvrGaze).
	public void OnGazeEnter ()
	{
		changecolor (Color.green);
		waitTime = 0f;
		SetGazedAt (true);

		//gazedAt = true;

	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit ()
	{
		changecolor (Color.white);
		SetGazedAt (false);
		waitTime = 0f;
		//pickupsound.SetActive (false);
		StartCoroutine(resetsound());


	}

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnPointerExit.
	public void OnGazeTrigger ()
	{
		//TeleportRandomly ();
		//ExecuteEvents.Execute(gazedAt,null,(DragDropHandler handler, BaseEventData data) => handler.HandleGazeTriggerStart());
	}
	//public void OnGazeTriggerStart()
	//{
	//ExecuteEvents.Execute(gazedAt,null,(DragDropHandler handler, BaseEventData data) => handler.HandleGazeTriggerStart());
	//}
	//public void OnGazeTriggerEnd()
	//{
	//ExecuteEvents.Execute(gazedAt,null,(DragDropHandler handler, BaseEventData data) => handler.HandleGazeTriggerStart());
	//}

	#endregion

	IEnumerator resetsound()
	{
		yield return new WaitForSeconds (2);
		pickupsound.SetActive (false);

	}
}

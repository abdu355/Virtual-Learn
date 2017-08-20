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
public class resetBtn : MonoBehaviour, IGvrGazeResponder
{
	private Vector3 startingPosition;

	public Material inactiveMaterial;
	public Material gazedAtMaterial;
	private bool gazedAtOb=false;
	private float waitTime = 0f;

	public float gazewaitTime = 10f;

	public GameObject player;
	public Camera cam;
	private GameObject reticle;
	public KeyCode pickupKey;


	private Ray ray;
	bool carrying;
	GameObject carriedObject;
	public GameObject pickupsound;

	public GameObject fire,smoke;
	//public float distance;
	//public float smooth;

	void Start ()
	{
		//reticle = GameObject.FindWithTag("Reticle");
		//pickupsound = GameObject.FindWithTag("pickupsound");
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
		//		if (carrying) {
		//			carry (carriedObject);
		//			checkDrop ();
		//		}
		//		else if (gazedAtOb) {
		//			waitTime++;
		//
		//			if (waitTime >= gazewaitTime) {
		//				reticle.GetComponent<Renderer> ().material.SetColor ("_Color", Color.magenta);
		//				ray = reticle.GetComponent<PickupObject> ().getRay ();
		//				Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);
		//
		//				RaycastHit hit;
		//				if(Physics.Raycast(ray, out hit)) {
		//					//Debug.DrawLine (transform.position, hit.point, Color.red);
		//					Pickupable p = hit.collider.GetComponent<Pickupable>();
		//					if(p != null) {
		//						Debug.Log ("carrying");
		//						carrying = true;
		//						carriedObject = p.gameObject;
		//						//p.gameObject.rigidbody.isKinematic = true;
		//						p.gameObject.GetComponent<Rigidbody>().useGravity = false;
		//					}
		//				}
		//			}
		//		}
		if (gazedAtOb == true) {
			//Debug.Log ("" + waitTime);
			waitTime++;
			if (gameObject.tag == "resetbtn" && waitTime >= gazewaitTime) {
				Debug.Log ("resetchemshow");
				resetChemistry ();
			}
		}
	}
	//	void checkDrop() {
	//		if(Input.GetButtonDown("C")) {
	//			dropObject();
	//		}
	//	}
	//
	//	public void dropObject() {
	//		carrying = false;
	//		//carriedObject.gameObject.rigidbody.isKinematic = false;
	//		carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
	//		carriedObject = null;
	//	}
	//	void carry(GameObject o) {
	//		o.transform.position = Vector3.Lerp (o.transform.position, reticle.transform.position + reticle.transform.forward * distance, Time.deltaTime * smooth);
	//		//o.transform.position = ray.GetPoint(distance);
	//		o.transform.rotation = Quaternion.identity;
	//	}

	public void SetGazedAt (bool gazedAt)
	{
		//Debug.Log ("gazed at");
		gazedAtOb = gazedAt;
		if (inactiveMaterial != null && gazedAtMaterial != null) {
			GetComponent<Renderer> ().material = gazedAt ? gazedAtMaterial : inactiveMaterial;
			return;
		}
		if(GetComponent<Renderer> ()!=null)
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
	public void resetChemistry()
	{
		//GameObject.FindGameObjectWithTag ("thermitesmoke").GetComponent<ParticleSystem> ().Stop ();
		//GameObject.FindGameObjectWithTag ("yellowsmoke").GetComponent<ParticleSystem> ().Stop ();
		fire.SetActive(false);
		//smoke.SetActive(false);
	}

	//	public void pickUp ()
	//	{
	//		
	//		GetComponent<Rigidbody> ().isKinematic = true;
	//		transform.parent = player.transform;
	//		transform.position = new Vector3 (reticle.transform.position.x - 1f, reticle.transform.position.y, reticle.transform.position.z - 1.5f);
	//
	//
	//	}

	#region IGvrGazeResponder implementation

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see GvrGaze).
	public void OnGazeEnter ()
	{
		//reticle.GetComponent<Renderer> ().material.SetColor ("_Color", Color.green);
		//waitTime = 0f;
		SetGazedAt (true);

	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit ()
	{
		//reticle.GetComponent<Renderer> ().material.SetColor ("_Color", Color.white);
		SetGazedAt (false);
		StartCoroutine (resetsound ());
		//waitTime = 0f;

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
		if(pickupsound!=null)
			pickupsound.SetActive (false);

	}
}

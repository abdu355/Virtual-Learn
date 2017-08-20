using UnityEngine;
using System.Collections;
 
public class PickupObject : MonoBehaviour {
    GameObject mainCamera, player;
	public GameObject pickupsound;
    bool carrying;
    GameObject carriedObject;
    public float distance;
    public float smooth;
	private Ray ray,ray2;

	private GameObject reticle;

    // Use this for initialization
    void Start () {
        mainCamera = GameObject.FindWithTag("MainCamera");
		player = GameObject.FindWithTag ("Player");
		reticle = GameObject.FindWithTag ("Reticle");
		//ray2 = new Ray(reticle.transform.position, reticle.transform.forward);
    }
     
    // Update is called once per frame
    void Update () {
		//int x = Screen.width / 2;
		//int y = Screen.height / 2;
		ray2 = new Ray(reticle.transform.position, reticle.transform.forward);
		Debug.DrawRay(ray2.origin, ray2.direction * 1000, Color.red);


        if(carrying) {
            carry(carriedObject);
            checkDrop();
            //rotateObject();
        } else {
            pickup();
        }
    }
 
    void rotateObject() {
        carriedObject.transform.Rotate(5,10,15);
    }
 
    void carry(GameObject o) {
		o.transform.position = Vector3.Lerp (o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
		//o.transform.position = ray.GetPoint(distance);
        o.transform.rotation = Quaternion.identity;
    }
 
    void pickup() {
		if(Input.GetButtonDown("C")) {
            //int x = Screen.width / 2;
            //int y = Screen.height / 2;
 
			//Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(reticle.transform.position);
			ray = new Ray(reticle.transform.position, reticle.transform.forward);
	
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
				//Debug.DrawLine (transform.position, hit.point, Color.red);
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if(p != null) {
					if(pickupsound!=null)
						pickupsound.SetActive (true);
                    carrying = true;
                    carriedObject = p.gameObject;
                    //p.gameObject.rigidbody.isKinematic = true;
                    p.gameObject.GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }
    }
	public Ray getRay()
	{
		return ray2;
	}
 
    void checkDrop() {
		if(Input.GetButtonDown("C")) {
            dropObject();
        }
    }
 
    void dropObject() {
        carrying = false;
        //carriedObject.gameObject.rigidbody.isKinematic = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject = null;

    }
		
}
using UnityEngine;
using System.Collections;

public class SnappableBow : MonoBehaviour {
	
	// non-primitive type arrow object
	//public GameObject snappableBow;

	public GameObject snappableBow;

	public GameObject snapNode;

	public bool arrowConnected = false;

	public float lastArrowZPosition;
	public float pullbackOffset; 
	
	// Use this for initialization
	void Start () {
		// primitive type arrow object
		//snappableBowP = GameObject.CreatePrimitive (PrimitiveType.Cube);
		//snappableBowP.AddComponent<Rigidbody> ();
		//snappableBowP.transform.position = new Vector3 (2, 3, -3);
		//snappableBowP.transform.rotation = new Quaternion (0, 0, 0, 0);
		//snappableBowP.transform.localScale = new Vector3 (0.5f, 5f, 0.5f);

		AddSnapNode (snappableBow);
	}
	
	void AddSnapNode(GameObject snappableBow)
	{
		snapNode = GameObject.CreatePrimitive (PrimitiveType.Sphere);

		// put the snapNode in the midpoint of the x and y axis, on the edge of the z axis of the bow object
		//snapNode.transform.position =new Vector3(0.05f,2.5f,0f);

		snapNode.transform.position = snappableBow.transform.position;

		snapNode.transform.localScale = new Vector3 (0.75f, 0.75f, 0.75f);

		// Red node
		snapNode.renderer.material.color = Color.red;

		snapNode.collider.isTrigger = true;
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "snappableArrow")
		{
			//print("Collision");
			collision.transform.parent = transform;
			collision.transform.position = new Vector3(transform.position.x-0.5f,
			                                           transform.position.y,
			                                           transform.position.z);
			arrowConnected = true;

			lastArrowZPosition = collision.transform.position.z;

		}
	}

	void detectArrowPullback()
	{
		GameObject snappableArrow = GameObject.Find("snappableArrow");

		pullbackOffset = snappableArrow.transform.position.z - lastArrowZPosition;

		// If the arrow moves past this threshold, apply a forward force proportional to the change in z position
		// and set arrowConnected to false
		float pullbackThreshold = 1;

		if (pullbackOffset > pullbackThreshold)
		{
			snappableArrow.transform.parent = null;
			snappableArrow.rigidbody.useGravity = true;
			snappableArrow.rigidbody.AddForce(Vector3.forward * 1000 * pullbackOffset);
			snappableArrow.rigidbody.detectCollisions = false;
			arrowConnected = false;
		}
	}

	// Update is called once per frame
	void Update () {
		snapNode.transform.position = snappableBow.transform.position;
		// Keep the bow object from rotating - makes it easier to control
		snappableBow.transform.rotation = new Quaternion (0, 0, 0, 0);

		if (arrowConnected)
		{
			GameObject snappableArrow = GameObject.Find("snappableArrow");
			// Keep the arrow fixed onto the bow in the x and y axes
			// Allow movement forwards and backwards in the z axis e.g. drawing back motion
			//snappableArrow.transform.position = new Vector3(snappableBow.transform.position.x-0.5f,
			//                                                snappableBow.transform.position.y, 0);
			//                                                snappableBow.transform.position.z);
			snappableArrow.transform.position = new Vector3(snappableBow.transform.position.x -0.5f,
			                                                snappableBow.transform.position.y,
			                                                snappableArrow.transform.position.z);

			snappableArrow.rigidbody.useGravity = false;

			detectArrowPullback();
		}
	}
}

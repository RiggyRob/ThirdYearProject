using UnityEngine;
using System.Collections;

public class SnappableBow : MonoBehaviour {
	
	// non-primitive type arrow object
	public GameObject snappableBow;

	public GameObject snappableBowP;

	public GameObject snapNode;
	
	// Use this for initialization
	void Start () {
		// primitive type arrow object
		snappableBowP = GameObject.CreatePrimitive (PrimitiveType.Cube);
		snappableBowP.AddComponent<Rigidbody> ();
		snappableBowP.transform.position = new Vector3 (2, 3, -3);
		snappableBowP.transform.rotation = new Quaternion (0, 0, 0, 0);
		snappableBowP.transform.localScale = new Vector3 (0.5f, 5f, 0.5f);

		AddSnapNode (snappableBowP);
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
	
	// Update is called once per frame
	void Update () {
		snapNode.transform.position =snappableBowP.transform.position;
		// Keep the bow object from rotating - makes it easier to control
		snappableBowP.transform.rotation = new Quaternion (0, 0, 0, 0);

	}
}

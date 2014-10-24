using UnityEngine;
using System.Collections;

public class SnappableBow : MonoBehaviour {
	
	// non-primitive type arrow object
	public GameObject snappableBow;
	
	// Use this for initialization
	void Start () {
		// primitive type arrow object
		GameObject snappableBowP = GameObject.CreatePrimitive (PrimitiveType.Cube);
		snappableBowP.AddComponent<Rigidbody> ();
		snappableBowP.transform.position = new Vector3 (2, 3, -3);
		snappableBowP.transform.rotation = new Quaternion (0, 0, 0, 0);
		snappableBowP.transform.localScale = new Vector3 (0.5f, 5f, 0.5f);

		AddSnapNode (snappableBow);
	}
	
	void AddSnapNode(GameObject snappableBow)
	{
		GameObject snapNode = new GameObject();

		// put the snapNode in the midpoint of the x and y axis, on the edge of the z axis of the bow object
		snapNode.transform.position =new Vector3(0.05f,2.5f,0f);

		//snapNode.transform.position =new Vector3(snappableBow.transform.position.x/2,
		//                                         snappableBow.transform.position.y/2,
		//                                         snappableBow.transform.position.z);

		// Red node
		snapNode.AddComponent<Renderer> ();
		snapNode.renderer.material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

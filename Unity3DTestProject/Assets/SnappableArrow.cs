using UnityEngine;
using System.Collections;

public class SnappableArrow : MonoBehaviour {
	
	// non-primitive type arrow object
	public GameObject snappableArrow;
	
	// Use this for initialization
	void Start () {
		// primitive type arrow object
		GameObject snappableArrowP = GameObject.CreatePrimitive (PrimitiveType.Cube);
		snappableArrowP.AddComponent<Rigidbody> ();
		snappableArrowP.transform.position = new Vector3 (0, 0, 0);
		snappableArrowP.transform.rotation = new Quaternion(0,90,0,0);
		snappableArrowP.transform.localScale = new Vector3 (5.0f, 0.1f, 0.1f);

		AddSnapNode (snappableArrow);
	}
	
	void AddSnapNode(GameObject snappableArrow)
	{
		GameObject snapNode = new GameObject ();

		// put the snapNode in the midpoint of the x and y axis, on the edge of the z axis of the arrow object
		snapNode.transform.position =new Vector3(2.5f,0.05f,0.1f);

		//snapNode.transform.position =new Vector3(snappableArrow.transform.position.x/2,
		//                                         snappableArrow.transform.position.y/2,
		//                                         snappableArrow.transform.position.z);

		// Red node
		snapNode.AddComponent<Renderer> ();
		snapNode.renderer.material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

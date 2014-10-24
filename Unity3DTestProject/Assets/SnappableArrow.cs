﻿using UnityEngine;
using System.Collections;

public class SnappableArrow : MonoBehaviour {
	
	// non-primitive type arrow object
	public GameObject snappableArrow;

	public GameObject snappableArrowP;

	public GameObject snapNode;

	// Use this for initialization
	void Start () {
		// primitive type arrow object
		snappableArrowP = GameObject.CreatePrimitive (PrimitiveType.Cube);
		snappableArrowP.AddComponent<Rigidbody> ();
		snappableArrowP.transform.position = new Vector3 (0, 0, 0);
		snappableArrowP.transform.rotation = new Quaternion(0,90,0,0);
		snappableArrowP.transform.localScale = new Vector3 (0.1f, 0.1f, 5.0f);

		AddSnapNode (snappableArrowP);
	}
	
	void AddSnapNode(GameObject snappableArrow)
	{
		snapNode = GameObject.CreatePrimitive (PrimitiveType.Sphere);

		// put the snapNode in the midpoint of the x and y axis, on the edge of the z axis of the arrow object
		//snapNode.transform.position =new Vector3(2.5f,0.05f,0.1f);

		snapNode.transform.position = snappableArrow.transform.position;
		snapNode.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);

		// Red node
		snapNode.renderer.material.color = Color.red;

		snapNode.collider.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
		snapNode.transform.position = snappableArrowP.transform.position;
		// Keep the arrow object from rotating - makes it easier to control
		snappableArrowP.transform.rotation = new Quaternion(0,90,0,0);

	}
}

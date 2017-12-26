using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPlane : MonoBehaviour 
{
	public event System.Action<Collision> OnEnteredCollision;

	public float Scale
	{ get { return this.planeTransform.localScale.x; } }

	private Transform planeTransform = null;

	private void Start()
	{
		StorePlaneTransform();
		ListenToCollisionEvents();
	}

	private void StorePlaneTransform()
	{
		this.planeTransform = this.transform.GetChild(0);
	}

	private void ListenToCollisionEvents()
	{
		CollisionEventBubbler collisionBubbler = this.planeTransform.GetComponent<CollisionEventBubbler>();
		collisionBubbler.OnEnteredCollision += EnteredCollision;
	}

	private void EnteredCollision(Collision collision)
	{
		if(OnEnteredCollision != null)
		{ OnEnteredCollision(collision); }
	}
}
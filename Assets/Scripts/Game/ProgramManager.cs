using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramManager : MonoBehaviour 
{
	private const string _arLayerName = "ARPlane";

	[SerializeField] private UnityARInterface.ARPlaneVisualizer arPlaneVisualizer = null;

	private void Start()
	{
		ListenToEvents();
	}

	private void OnDestroy()
	{
		StopListenToEvents();	
	}

	private void ListenToEvents()
	{
		MainMessenger.Instance.OnPlayerTapped += OnPlayerTapped;
	}

	private void StopListenToEvents()
	{
		MainMessenger.Instance.OnPlayerTapped -= OnPlayerTapped;
	}

	private void OnPlayerTapped(RaycastHit hit)
	{
		GameObject collisionObj = hit.collider.gameObject;
		if(collisionObj.layer != LayerMask.NameToLayer(_arLayerName))
		{ return; }
		
		Transform planeParent = collisionObj.transform.parent;
		PlaneSelected(planeParent.GetComponent<WorldPlane>());
		StopListenToEvents();

		StartGame();
	}

	private void PlaneSelected(WorldPlane worldPlane)
	{
		MainMessenger.Instance.PlaneSelected(worldPlane);

		this.arPlaneVisualizer.enabled = false;
	}

	private void StartGame()
	{
		MainMessenger.Instance.StartGame();
	}
}
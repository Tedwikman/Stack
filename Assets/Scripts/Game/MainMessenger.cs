using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMessenger 
{
	public static MainMessenger Instance
	{
		get 
		{
			if(_instance == null)
			{ _instance = new MainMessenger(); }
			return _instance;
		}
	}
	private static MainMessenger _instance = null;

	public event System.Action<RaycastHit> OnPlayerTapped;
	public event System.Action<WorldPlane> OnPlaneSelected;
	public event System.Action OnStartingGame;
	public event System.Action<GameStates> OnSwitchGameState;
	public event System.Action OnBlockPlaced;
	public event System.Action<string> OnAnnounceWinner;

	public void PlayerTapped(RaycastHit hit)
	{
		if(OnPlayerTapped != null)
		{ OnPlayerTapped(hit); }
	}

	public void PlaneSelected(WorldPlane plane)
	{
		if(OnPlaneSelected != null)
		{ OnPlaneSelected(plane); }
	}

	public void StartGame()
	{
		if(OnStartingGame != null)
		{ OnStartingGame(); }
	}

	public void SwitchGameState(GameStates newState)
	{
		if(OnSwitchGameState != null)
		{ OnSwitchGameState(newState); }		
	}

	public void BlockPlaced()
	{
		if(OnBlockPlaced != null)
		{ OnBlockPlaced(); }		
	}

	public void AnnounceWinner(string winnerName)
	{
		if(OnAnnounceWinner != null)
		{ OnAnnounceWinner(winnerName); }		
	}
}
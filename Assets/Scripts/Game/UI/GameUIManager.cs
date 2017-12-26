using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour 
{
	[SerializeField] private GameObject setupPanel = null;
	[SerializeField] private GameObject playerOnePanel = null;
	[SerializeField] private GameObject playerTwoPanel = null;
	[SerializeField] private GameObject gameOverPanel = null;

	private void Awake()
	{
		ListenToEvents();
	}
	
	private void ListenToEvents()
	{
		MainMessenger.Instance.OnSwitchGameState += OnSwitchGameState;
	}

	private void OnSwitchGameState(GameStates newGameState)
	{
		this.setupPanel.SetActive(newGameState == GameStates.Setup);
		this.playerOnePanel.SetActive(newGameState == GameStates.PlayerOne);
		this.playerTwoPanel.SetActive(newGameState == GameStates.PlayerTwo);
		this.gameOverPanel.SetActive(newGameState == GameStates.GameOver);
	}
}

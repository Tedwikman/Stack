using UnityEngine;

public class GameManager : MonoBehaviour
{
    private WorldPlane worldPlane = null;

    private bool firstObjectSpawned = false;
    private GameStates currentGameState = GameStates.Setup;

    private void Awake()
    {
        ListenToProgramStates();
    }

    private void Start()
    { 
        SetGameState(GameStates.Setup);
    }

    private void ListenToProgramStates()
    {
        MainMessenger.Instance.OnPlaneSelected += OnPlaneSelected;
        MainMessenger.Instance.OnStartingGame += OnStartingGame;
        MainMessenger.Instance.OnBlockPlaced += OnBlockPlaced;
        MainMessenger.Instance.OnPlayerTapped += OnPlayerTapped;
    }

    private void OnPlaneSelected(WorldPlane worldPlane)
    {
        this.worldPlane = worldPlane;
    }

    private void OnStartingGame()
    {
        ListenToGameEvents();
        RestartGame();
    }

    private void RestartGame()
    {
        this.firstObjectSpawned = false;
        SetGameState(GameStates.PlayerOne);
    }

    private void ListenToGameEvents()
    {
        this.worldPlane.OnEnteredCollision += OnEnteredCollision;
    }

    private void OnBlockPlaced()
    {
        if(!AssertIsPlaying())
        { return; }

        GameStates newState = this.currentGameState == GameStates.PlayerOne ? GameStates.PlayerTwo : GameStates.PlayerOne;
        SetGameState(newState);
    }

    private bool AssertIsPlaying()
    {
        return this.currentGameState == GameStates.PlayerOne ||
            this.currentGameState == GameStates.PlayerTwo;
    }

    private void OnEnteredCollision(Collision collision)
    {
        if(!this.firstObjectSpawned)
        {
            this.firstObjectSpawned = true;
            return;
        }

        EndGame();
    }

    private void EndGame()
    {
        string winnerID = this.currentGameState == GameStates.PlayerOne ? "Player One" : "Player Two";

        SetGameState(GameStates.GameOver);
        MainMessenger.Instance.AnnounceWinner(winnerID);

        BlockManager.Instance.RemoveAllBlocks();
    }

    private void SetGameState(GameStates newGameState)
    {
        this.currentGameState = newGameState;
        MainMessenger.Instance.SwitchGameState(newGameState);
    }

    private void OnPlayerTapped(RaycastHit hit)
    {
        if(this.currentGameState != GameStates.GameOver)
        { return; }

        RestartGame();
    }
}
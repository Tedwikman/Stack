using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform predictionBlock = null;

    private GameStates currentGameState = GameStates.Setup;
    private float planeScaleFactor = 1f;

    private void Start()
    {
        ListenToEvents();
        TogglePredictionBlock(false);
    }

    private void ListenToEvents()
    {
        MainMessenger.Instance.OnPlaneSelected += OnPlaneSelected;
        MainMessenger.Instance.OnSwitchGameState += OnSwitchGameState;
        MainMessenger.Instance.OnPlayerTapped += OnPlayerTapped;
    }

    private void OnPlaneSelected(WorldPlane worldPlane)
    {
        this.planeScaleFactor = worldPlane.Scale;
        this.predictionBlock.localScale = Vector3.one * this.planeScaleFactor;
    }

    private void OnSwitchGameState(GameStates newState)
    {
        this.currentGameState = newState;

        if(AssertIsPlaying())
        { TogglePredictionBlock(true); }
    }

    private void OnPlayerTapped(RaycastHit hit)
    {
        if(!AssertIsPlaying())
        { return; }

        int playerID = this.currentGameState == GameStates.PlayerOne ? 0 : 1;
        SpawnBlockAtPos(hit.point, playerID);
    }

    private bool AssertIsPlaying()
    {
        return this.currentGameState == GameStates.PlayerOne ||
            this.currentGameState == GameStates.PlayerTwo;
    }

    private void SpawnBlockAtPos(Vector3 worldPoint, int playerID)
    {
        TogglePredictionBlock(false);

        Vector3 planeOffset = Vector3.up * (0.5f * this.planeScaleFactor);
        Vector3 spawnPoint = worldPoint + planeOffset;
        BlockSpawner.Instance.SpawnBlockAt(spawnPoint, this.planeScaleFactor, playerID);
    }

    private void TogglePredictionBlock(bool isActive)
    {
        this.predictionBlock.gameObject.SetActive(isActive);
    }
}
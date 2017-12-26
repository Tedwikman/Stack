using UnityEngine;
using UnityEngine.UI;

public class GameOverUIPanel : MonoBehaviour
{
    [SerializeField] private Text winnerLabel = null;

    private void Awake()
    {
        ListenToEvents();
    }

    private void ListenToEvents()
    {
        MainMessenger.Instance.OnAnnounceWinner += OnAnnounceWinner;
    }

    private void OnAnnounceWinner(string winnerID)
    {
        this.winnerLabel.text = "WINNER: " + winnerID;
    }
}
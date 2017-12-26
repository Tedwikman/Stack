using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour 
{
	public void PressStartButton()
	{
		SceneManager.LoadScene("Game");
	}
}

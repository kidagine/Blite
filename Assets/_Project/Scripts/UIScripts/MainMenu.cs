using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	public void StartGame()
	{
		SceneManager.LoadScene(2);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}

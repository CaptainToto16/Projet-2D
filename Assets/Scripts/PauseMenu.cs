using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] GameObject pauseMenu;
	
	private bool isPaused = false;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	}

	public void Pause()
	{
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		isPaused = true;
	}

	public void Home()
	{
		Debug.Log("clicked home	");
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
		
	}

	public void Resume()
	{
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
		isPaused = false;
	}

	public void Restart()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}


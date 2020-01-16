using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
	public void LoadByName(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

	public void Quit()
	{
		Application.Quit();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    void Start()
    {
        
    }
	
    void Update()
    {
        
    }

	public void mainMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void levelSelection()
	{
		SceneManager.LoadScene(4);			//level selection scene
	}

	public void helpMenu()
	{
		SceneManager.LoadScene(5);			//help menu scene
	}

	public void levelSelect(int index)
	{
		SceneManager.LoadScene(index);
	}
}

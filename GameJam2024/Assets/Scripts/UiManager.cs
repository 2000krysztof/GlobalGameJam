using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
	public static UiManager Singleton;


    void Awake()
    {
        if(Singleton == null){
			Singleton = this;
		}else{
			Destroy(Singleton.gameObject);
			Singleton = this;
		}
    }


	public RectTransform[] toggleAbles;

	private bool isPaused = false;

	public void TogglePause(){
		if(isPaused){
			ResumeGame();
		}else{
			PauseGame();
		}
	}	

	public void PauseGame(){
		Time.timeScale = 0;
		isPaused = true;

		foreach(RectTransform rectT in toggleAbles){
			rectT.gameObject.SetActive(true);
		}
	}


	public void ResumeGame(){
		Time.timeScale = 1;
		isPaused = false;
		
		foreach(RectTransform rectT in toggleAbles){
			rectT.gameObject.SetActive(false);
		}
	}


	public void BackToMainMenu(){
		SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));	
	}


	public void ExitGame(){
		Application.Quit();
	}
}







using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour {
private GameObject m_activeState;
public GameObject[] m_gameStates;
public Text m_leveltransist;
public Button m_changeLevel;
public GameObject m_player;
public Camera m_mainCam;
public int m_levelCount;

public AudioSource m_sound_mgr;
	// Use this for initialization
	void Start () {
		int numStates = m_gameStates.Length;
		for(int i=0;i<numStates;i++){
			m_gameStates[i].SetActive(false);
	
		}
		m_mainCam.GetComponent<CameraScroll>().enabled=false;
		m_activeState=m_gameStates[0];
		m_activeState.SetActive(true);
		m_changeLevel.onClick.AddListener(TaskOnClick);
	}
	
	void TaskOnClick(){
		
		
		if(m_levelCount == 1){
			
			m_levelCount = 2;
			Level2();
		}
		if(m_levelCount == 3){
			
			m_levelCount = 3;
			Level3();
		}
	}
	// Update is called once per frame
	void Update () {
	
		// if(m_activeState == m_gameStates[0]){
		// 	StartCoroutine(Splash());
		// }
	}
	IEnumerator Splash(){
		yield return new WaitForSeconds(3);
		Menu();
	}
	public void Exit(){
		 #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
     #else
         Application.Quit();
     #endif
	}

	public void Menu(){
		m_activeState.SetActive(false);
		m_activeState = m_gameStates[0];
		m_activeState.SetActive(true);
	}

	public void PlayGame(){
		m_activeState.SetActive(false);
		m_levelCount=1;
		m_activeState = m_gameStates[1];
		m_activeState.SetActive(true);
		m_sound_mgr.Play();
		m_mainCam.GetComponent<CameraScroll>().enabled=true;
		m_player.SetActive(true);
	}

	public void GameOver(){
		m_activeState.SetActive(false);
		m_activeState = m_gameStates[2];
		m_activeState.SetActive(true);
		
	}
	public void FinishLevel(){
		Debug.Log(m_player.GetComponent<PlayerController>().m_startPos);
		m_leveltransist.text ="Congrats! You Finished Level: "+ m_levelCount + "!";
		m_activeState.SetActive(false);
		m_activeState = m_gameStates[4];
		m_mainCam.GetComponent<CameraScroll>().enabled=false;
		m_mainCam.transform.position = m_mainCam.GetComponent<CameraScroll>().m_camStartPos;
		m_player.transform.position = m_player.GetComponent<PlayerController>().m_startPos;
		m_activeState.SetActive(true);
		
	}
	public void Level2(){
		
		m_activeState.SetActive(false);
		m_activeState = m_gameStates[3];
		m_activeState.SetActive(true);
		m_mainCam.GetComponent<CameraScroll>().enabled=true;

	}
	public void Level3(){
		
		m_activeState.SetActive(false);
		m_activeState = m_gameStates[5];
		m_activeState.SetActive(true);
		m_mainCam.GetComponent<CameraScroll>().enabled=true;

	}
}

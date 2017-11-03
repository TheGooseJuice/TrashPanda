using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	private static GameManager instance=null;
	public static GameManager Instance{get{return instance;}}
	public Image m_oneHealth;
	public Image m_twoHealth;
	public Image m_threeHealth;

	// Use this for initialization
	void Awake(){
	if(instance !=null && instance !=this){
		Destroy(this.gameObject);
		return;
	}else{
		instance=this;
	}
	DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Enable3Hearts(){
		m_oneHealth.enabled=true;
		m_twoHealth.enabled=true;
		m_threeHealth.enabled=true;
	} 
	public void Enable2Hearts(){
		m_oneHealth.enabled=true;
		m_twoHealth.enabled=true;
		m_threeHealth.enabled=false;
	} 
	public void Enable1Hearts(){
		m_oneHealth.enabled=true;
		m_twoHealth.enabled=false;
		m_threeHealth.enabled=false;
	} 
}

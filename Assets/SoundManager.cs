using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioSource m_soundmgr;
	public AudioClip m_sfkWallhit;
	public AudioClip m_sfkcathit;
	public AudioClip m_sfkCatMeow;
	public AudioClip m_sfkCoonHit;
	// Use this for initialization
	private static SoundManager instance=null;
	public static SoundManager Instance{get{return instance;}}
	void Awake(){
	if(instance !=null && instance !=this){
		Destroy(this.gameObject);
		return;
		}else{
			instance=this;
		}
		
		DontDestroyOnLoad(this.gameObject);
	}
	
	public void playCatMeow(){
		m_soundmgr.PlayOneShot(m_sfkCatMeow);
	}
	public void playCoonhit(){
		m_soundmgr.PlayOneShot(m_sfkCoonHit);
	}
	public void playcathit(){
		m_soundmgr.PlayOneShot(m_sfkcathit);
	}
	public void playwallhit(){
		m_soundmgr.PlayOneShot(m_sfkWallhit);
	}
}

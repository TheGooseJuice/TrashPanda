using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	private static GameManager instance=null;
	public static GameManager Instance{get{return instance;}}
	public GameObject m_oneHealth;
	public GameObject m_twoHealth;
	public GameObject m_threeHealth;
	public GameObject[] m_weaponUI;
	public GameObject m_player;
	public GameObject m_bulletContainer;
	public float m_levelNum;

	// Use this for initialization
	void Awake(){
	if(instance !=null && instance !=this){
		Destroy(this.gameObject);
		return;
	}else{
		instance=this;
	}
	DontDestroyOnLoad(this.gameObject);
		for(int i=0;i<m_weaponUI.Length; i++){
			m_weaponUI[i].SetActive(false);
		}
		m_levelNum = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void FireBullet(GameObject m_bulletprefab){
		GameObject newBullet=Instantiate(m_bulletprefab,m_player.transform.position,Quaternion.identity);
		newBullet.transform.parent=m_bulletContainer.transform;
		//newBullet.GetComponent.
	}
	public void TripShot(GameObject m_bulletprefab){
		GameObject newBullet=Instantiate(m_bulletprefab,m_player.transform.position,Quaternion.identity);
		GameObject leftBullet=Instantiate(m_bulletprefab,m_player.transform.position,Quaternion.Euler(new Vector3(0,0,10)));
		leftBullet.GetComponent<Bullet>().m_left=true;
		GameObject RightBullet=Instantiate(m_bulletprefab,m_player.transform.position,Quaternion.Euler(new Vector3(0,0,-10)));
		RightBullet.GetComponent<Bullet>().m_right=true;
		newBullet.transform.parent=m_bulletContainer.transform;
		leftBullet.transform.parent=m_bulletContainer.transform;
		RightBullet.transform.parent=m_bulletContainer.transform;
		//newBullet.GetComponent.
	}
	public void Enable3Hearts(){
		m_oneHealth.SetActive(true);
		m_twoHealth.SetActive(true);
		m_threeHealth.SetActive(true);
	} 
	public void Enable2Hearts(){
		m_oneHealth.SetActive(true);
		m_twoHealth.SetActive(true);
		m_threeHealth.SetActive(false);
	} 
	public void Enable1Hearts(){
		m_oneHealth.SetActive(true);
		m_twoHealth.SetActive(false);
		m_threeHealth.SetActive(false);
	} 
	public void EquipHotDog(){
	
		for(int i=0;i<m_weaponUI.Length; i++){
			m_weaponUI[i].SetActive(false);
		}
		m_weaponUI[0].SetActive(true);
	}
	public void EquipTomato(){
		for(int i=0;i<m_weaponUI.Length; i++){
			m_weaponUI[i].SetActive(false);
		}
		m_weaponUI[1].SetActive(true);
	}
	public void EquipCandy(){
		
		for(int i=0;i<m_weaponUI.Length; i++){
			m_weaponUI[i].SetActive(false);
		}
		m_weaponUI[2].SetActive(true);
	}
	public void EquipBeans(){
		for(int i=0;i<m_weaponUI.Length; i++){
			m_weaponUI[i].SetActive(false);
		}
		m_weaponUI[3].SetActive(true);
	}
	public void EquipGun(){
		for(int i=0;i<m_weaponUI.Length; i++){
			m_weaponUI[i].SetActive(false);
		}
		m_weaponUI[4].SetActive(true);
	}
	public void EquipRpg(){
		for(int i=0;i<m_weaponUI.Length; i++){
			m_weaponUI[i].SetActive(false);
		}
		m_weaponUI[5].SetActive(true);
	}

}

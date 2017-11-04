using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapons{ HOTDOG,TOMATO, CANDY, BEANS, GUN, RPG};
public class PlayerController : MonoBehaviour {
	private Rigidbody m_rb;
	public float m_moveSpeed=1.0f;
	public float m_life;
	private Vector3 middle;
	public Camera m_mainCam;
	public StateManager m_state_mgr;
	public Weapons m_currentWeapon;
	public GameObject[] m_bulletprefabs;
	void Awake () {
		m_rb = gameObject.GetComponent<Rigidbody>();
		m_life=3;
		middle = transform.position;
		transform.parent=m_mainCam.transform;
		m_currentWeapon=Weapons.HOTDOG;
	}
	
	// Update is called once per frame
	void Update () {
	
		
		if(Input.GetAxis("Horizontal") != 0){
			Vector3 pos = gameObject.transform.position;
			pos.x+=Input.GetAxis("Horizontal")*m_moveSpeed*Time.deltaTime;
			gameObject.transform.position=pos;
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			if(m_currentWeapon == Weapons.HOTDOG){
				GameManager.Instance.FireBullet(m_bulletprefabs[0]);
			}
			
			GameManager.Instance.EquipHotDog();
		}
		if(m_life == 3){
			GameManager.Instance.Enable3Hearts();
		}
		if(m_life == 2){
			GameManager.Instance.Enable2Hearts();
		}
		if(m_life == 1){
			GameManager.Instance.Enable1Hearts();
		}
		if(m_life == 0){
			m_state_mgr.GameOver();
			
		}
		if(m_currentWeapon == Weapons.HOTDOG){
			
			GameManager.Instance.EquipHotDog();
		}
		else if(m_currentWeapon == Weapons.TOMATO){
			GameManager.Instance.EquipTomato();
		}
	}
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Walls"){
			m_life-=1;
			Vector3 pos = transform.position;
			pos.x=middle.x;
			gameObject.transform.position=pos;
		}
		
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "TomatoPickup"){
			m_currentWeapon = Weapons.TOMATO;
			Destroy(other.gameObject);
		}
			if(other.gameObject.tag == "HotdogPickup"){
			m_currentWeapon = Weapons.HOTDOG;
			Destroy(other.gameObject);
		}
	}
}

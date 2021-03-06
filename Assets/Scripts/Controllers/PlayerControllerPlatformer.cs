﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerPlatformer : MonoBehaviour {
	private Rigidbody m_rb;
	public float m_moveSpeed=1.0f;
	public float m_life;
	private Vector3 middle;
	public Camera m_mainCam;
	public StateManager m_state_mgr;
	public Weapons m_currentWeapon;
	public GameObject[] m_bulletprefabs;
	public GameObject m_playerSprite;
	public Vector3 m_startPos;
	void Awake () {
		m_startPos=transform.position;
		m_rb = gameObject.GetComponent<Rigidbody>();
		m_life=3;
		middle = transform.position;
		transform.parent=m_mainCam.transform;
		m_currentWeapon=Weapons.HOTDOG;
	//	GameManager.Instance.EquipHotDog();
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(Input.GetKeyDown(KeyCode.A)){
			Vector3 pos = gameObject.transform.position;
			pos.x+=Input.GetAxis("Horizontal")*m_moveSpeed*Time.deltaTime;
			m_playerSprite.transform.localScale=new Vector3(-1.4f,6.5f,1);
			gameObject.transform.position=pos;
		}
		if(Input.GetKeyDown(KeyCode.D)){
			Vector3 pos = gameObject.transform.position;
			pos.x+=Input.GetAxis("Horizontal")*m_moveSpeed*Time.deltaTime;
			m_playerSprite.transform.localScale=new Vector3(1.4f,6.5f,1);
			gameObject.transform.position=pos;
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			if(m_currentWeapon == Weapons.HOTDOG){
				GameManager.Instance.FireBullet(m_bulletprefabs[0]);
			}
			if(m_currentWeapon == Weapons.TOMATO){
				GameManager.Instance.FireBullet(m_bulletprefabs[1]);
			}
			if(m_currentWeapon == Weapons.CANDY){
				GameManager.Instance.FireBullet(m_bulletprefabs[2]);
			}
			if(m_currentWeapon == Weapons.GUN){
				GameManager.Instance.FireBullet(m_bulletprefabs[3]);
			}
			if(m_currentWeapon == Weapons.RPG){
				GameManager.Instance.FireBullet(m_bulletprefabs[4]);
			}
		}
		if(Input.GetKeyUp(KeyCode.UpArrow)){
			Vector3 pos = gameObject.transform.position;
			pos.z+=Input.GetAxis("Vertical")*m_moveSpeed*Time.deltaTime;
			gameObject.transform.position=pos;
		}
		// if(m_life == 3){
		// 	GameManager.Instance.Enable3Hearts();
			
		// }
		// if(m_life == 2){
		// 	GameManager.Instance.Enable2Hearts();
		// }
		// if(m_life == 1){
		// 	GameManager.Instance.Enable1Hearts();
		// }
		// if(m_life == 0){
		// 	m_state_mgr.GameOver();
			
		// }
	
		
	}
	void OnCollisionEnter(Collision other){
	
		if(other.gameObject.tag == "enemy" ||other.gameObject.tag == "Hazard"){
			m_life-=1;
			Destroy(other.gameObject);
		}
	
		
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "TomatoPickup"){
			m_currentWeapon = Weapons.TOMATO;
			GameManager.Instance.EquipTomato();
			Destroy(other.gameObject);
		}
			if(other.gameObject.tag == "HotdogPickup"){
			m_currentWeapon = Weapons.HOTDOG;
			GameManager.Instance.EquipHotDog();
			Destroy(other.gameObject);
		}
			if(other.gameObject.tag == "CandyPickup"){
			m_currentWeapon = Weapons.CANDY;
			GameManager.Instance.EquipCandy();
			Destroy(other.gameObject);
		}
			if(other.gameObject.tag == "RpgPickup"){
			m_currentWeapon = Weapons.RPG;
			GameManager.Instance.EquipRpg();
			Destroy(other.gameObject);
		}
			if(other.gameObject.tag == "GunPickup"){
			m_currentWeapon = Weapons.GUN;
			GameManager.Instance.EquipGun();
			Destroy(other.gameObject);
			
		}
			if(other.gameObject.tag == "Spaghetti"){
			m_state_mgr.GetComponent<StateManager>().FinishLevel();
		}
			
	}
}

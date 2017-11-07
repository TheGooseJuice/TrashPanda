using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Collider ignoreCollider{ get; set;}
	
	private Rigidbody m_rb;
	public float m_speed=10f;
	public float m_acceleration;
	public bool m_isLeft;
	public bool m_isRight;
	void Awake(){
		m_rb=GetComponent<Rigidbody>();
		m_isLeft=false;
		m_isRight=false;
	}
	void Update(){
		Vector3 pos = gameObject.transform.position;
		pos.z+=m_speed*Time.deltaTime;
		if(m_isLeft){
			pos.y+=m_speed*Time.deltaTime;
		}
		if(m_isRight){
			pos.y-=m_speed*Time.deltaTime;
		}
		gameObject.transform.position=pos;
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Walls"||other.gameObject.tag == "Bounds")
		{
			Destroy(gameObject);
		}
		if(other.gameObject.tag != "Player"){
			//PoolManager.Instance.PoolObject(gameObject);
			//Destroy(gameObject);
		
			if(other.gameObject.layer == 8){
				//GameManager.Instance.BulletHit();
			}
		}
	}

}

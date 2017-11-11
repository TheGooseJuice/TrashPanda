using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	
	private Rigidbody m_rb;
	public float m_speed=10f;
	public Collider m_explosionCollider;
	public Animation m_anim;
	public float m_acceleration;
	
	void Awake(){
		m_rb=GetComponent<Rigidbody>();
		
	}
	void Update(){
		
		Vector3 pos = gameObject.transform.position;
		if(m_acceleration == 0){
			pos.z+=m_speed*Time.deltaTime;
			
		}
		else{
			pos.z+=m_speed*Time.deltaTime*m_acceleration;
			m_acceleration+=0.1f;
		}
		

		gameObject.transform.position=pos;
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Walls"||other.gameObject.tag == "enemy"||other.gameObject.tag == "Can")
		{

			Destroy(gameObject);
		}
		if(other.gameObject.tag == "Bounds"){
			
			Destroy(gameObject);
		}
	}
	void OnDestroy(){
		
		if(m_anim != null){
			m_anim.Play();
		}
		
	}

}



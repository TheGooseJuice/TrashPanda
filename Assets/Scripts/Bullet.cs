using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	
	private Rigidbody m_rb;
	public float m_speedZ=10f;
	public float m_speedX=2f;
	public Collider m_explosionCollider;
	public Animator m_anim;
	public float m_acceleration;
	public bool m_left;
	public bool m_right;
	void Awake(){
		m_rb=GetComponent<Rigidbody>();
		m_left=false;
		m_right=false;
	}
	void Update(){
	
		Vector3 pos = gameObject.transform.position;
		if(m_left){
			pos.z+=m_speedZ*Time.deltaTime;
			pos.x-=m_speedX*Time.deltaTime;
		}
		else if(m_right){	
			pos.z+=m_speedZ*Time.deltaTime;
			pos.x+=m_speedX*Time.deltaTime;
		}
		else if(m_acceleration == 0){
			pos.z+=m_speedZ*Time.deltaTime;
			
		}
		else{
			pos.z+=m_speedZ*Time.deltaTime*m_acceleration;
			m_acceleration+=0.1f;
		}
		

		gameObject.transform.position=pos;
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Walls"||other.gameObject.tag == "enemy"||other.gameObject.tag == "Can")
		{
			if(m_anim = null){
				m_anim.SetBool("Isded",true);
			}
			
			Destroy(gameObject);
		}
		if(other.gameObject.tag == "Bounds"){
			
			Destroy(gameObject);
		}
	}
	void OnDestroy(){
		if(m_explosionCollider!=null){
			m_explosionCollider.enabled=true;
		}
		
		//m_anim.SetBool("Isded",true);
		
	}

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Rigidbody m_rb;
	public float m_moveSpeed=1.0f;
	public float m_life;
	private Vector3 middle;
	public Camera m_mainCam;
	public StateManager m_state_mgr;
	void Awake () {
		m_rb = gameObject.GetComponent<Rigidbody>();
		m_life=3;
		middle = transform.position;
		transform.parent=m_mainCam.transform;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(m_life);
		if(Input.GetAxis("Horizontal") != 0){
			Vector3 pos = gameObject.transform.position;
			pos.x+=Input.GetAxis("Horizontal")*m_moveSpeed*Time.deltaTime;
			gameObject.transform.position=pos;
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
	}
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Walls"){
			m_life-=1;
			Vector3 pos = transform.position;
			pos.x=middle.x;
			gameObject.transform.position=pos;
		}
	}
}

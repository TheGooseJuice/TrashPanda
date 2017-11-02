using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Rigidbody m_rb;
	public float m_moveSpeed=1.0f;
	public float life;

	// Use this for initialization
	void Awake () {
		m_rb = gameObject.GetComponent<Rigidbody>();
		life=3;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Horizontal") != 0){
			Vector3 pos = gameObject.transform.position;
			pos.x+=Input.GetAxis("Horizontal")*m_moveSpeed*Time.deltaTime;
			gameObject.transform.position=pos;
	}
	}
}

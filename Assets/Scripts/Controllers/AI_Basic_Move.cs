using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Basic_Move : MonoBehaviour {

		public float m_moveSpeedX = -1.0f;

		public float m_moveSpeedZ = -0.0f;
		Vector3 pos=Vector3.zero;
	
	void Update () {
		 pos = gameObject.transform.position;
		pos.x+=m_moveSpeedX*/*GameManager.Instance.GameSpeed*/Time.deltaTime;
		gameObject.transform.position=pos;

		pos.z+=m_moveSpeedZ*/*GameManager.Instance.GameSpeed*/Time.deltaTime;
		gameObject.transform.position=pos;
	}
	void OnCollisionEnter(Collision other){
		pos = gameObject.transform.position;
		if(other.gameObject.tag == "Walls"){
			if(transform.localScale.x==-5){
				transform.localScale=new Vector3(5,5,1);
			}
			else{
				transform.localScale=new Vector3(-5,5,1);
			}
			m_moveSpeedX*=-1;
		}
	}
}

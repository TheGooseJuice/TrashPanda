using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Basic_Move : MonoBehaviour {

		public float m_moveSpeedX = -1.0f;
		public GameObject m_sprite;
		Vector3 pos=Vector3.zero;
	
	void Update () {
		pos = gameObject.transform.position;
		pos.x+=m_moveSpeedX*Time.deltaTime;
		gameObject.transform.position=pos;

	
	}
	void OnCollisionEnter(Collision other){
		
		

		if(other.gameObject.tag == "Walls"){
			
			if(m_sprite.transform.localScale.x==-1){
				m_sprite.transform.localScale=new Vector3(1,1,1);

			}
			else{Debug.Log("hitwall");
				m_sprite.transform.localScale=new Vector3(-1,1,1);
			}
			m_moveSpeedX*=-1;
			
		}
		
	}
}

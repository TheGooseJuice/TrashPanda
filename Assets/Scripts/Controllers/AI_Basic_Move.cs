using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Basic_Move : MonoBehaviour {

		public float m_moveSpeedX = -1.0f;

		public float m_moveSpeedZ = -0.0f;
	
	
	void Update () {
		Vector3 pos = gameObject.transform.position;
		pos.x+=m_moveSpeedX*/*GameManager.Instance.GameSpeed*/Time.deltaTime;
		gameObject.transform.position=pos;

		pos.z+=m_moveSpeedZ*/*GameManager.Instance.GameSpeed*/Time.deltaTime;
		gameObject.transform.position=pos;
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour {

		public float m_moveSpeed = 1.0f;
		public Vector3 m_camStartPos;
	void Start(){
		m_camStartPos=transform.position;
	}
	
	void Update () {
		Vector3 pos = gameObject.transform.position;
		pos.z+=m_moveSpeed*/*GameManager.Instance.GameSpeed*/Time.deltaTime;
		gameObject.transform.position=pos;
	}
}

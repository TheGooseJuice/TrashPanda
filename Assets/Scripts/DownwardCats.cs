using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownwardCats : MonoBehaviour {
	public float m_moveSpeedZ = -0.0f;
	public SpriteRenderer m_catSprite;
	Vector3 pos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(m_catSprite.enabled){
			pos = gameObject.transform.position;
			pos.z += m_moveSpeedZ * Time.deltaTime;
			gameObject.transform.position=pos;
		}
		
	}
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "DownWardEnemy"||other.gameObject.tag == "DownWardPenguins"){
			other.GetComponent<DownwardCats>().m_catSprite.enabled = true;
		}
	}
}

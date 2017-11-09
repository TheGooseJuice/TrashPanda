using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "enemy"){
			other.gameObject.SetActive(true);
		}
	}
}

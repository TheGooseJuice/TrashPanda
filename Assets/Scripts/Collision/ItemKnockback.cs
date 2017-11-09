using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemKnockback : MonoBehaviour {
     public void OnTriggerEnter(Collider other) {
         
          Debug.Log("SCOKS!");

         if(other.gameObject.tag =="Bullet"){

    
         Debug.Log("works!");
         // how much the character should be knocked back
         
         // calculate force vector
         Vector3 m_force = transform.position - other.transform.position;
         // normalize force vector to get direction only and trim magnitude
        // m_force.Normalize();
         gameObject.GetComponent<Rigidbody>().AddForce(m_force, ForceMode.Impulse);

        transform.Rotate(Time.deltaTime, 100, 0);
        
         
     }
     }


    public void OnCollisionEnter(Collision other){
         if(other.gameObject.tag =="Walls"){
             Destroy(gameObject);
         }
    }
}
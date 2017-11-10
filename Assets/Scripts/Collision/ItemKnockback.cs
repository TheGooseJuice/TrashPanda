using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemKnockback : MonoBehaviour {


     public void OnTriggerEnter(Collider other) {
         
          Debug.Log("SCOKS!");

         if(other.gameObject.tag =="Bullet"){

          // calculate force vector
          Vector3 m_force = transform.position - other.transform.position;
          gameObject.GetComponent<Rigidbody>().AddForce(m_force, ForceMode.Impulse);
         
             
              
              gameObject.GetComponent<Rigidbody>().AddTorque(transform.up * 100);
              
              
                
                  gameObject.GetComponent<Rigidbody>().AddTorque(transform.right * 100);
              

          gameObject.GetComponent<BoxCollider>().enabled=false;
          
         }
     
         

  //  public void OnCollisionEnter(Collision other){
       //  if(other.gameObject.tag =="Walls"){
//             Destroy(gameObject);
    //     }
  //  }
}

}
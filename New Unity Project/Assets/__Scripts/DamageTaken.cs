    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaken : MonoBehaviour
{
    void OnCollisionEnter(Collision col){
        if(col.gameObject.name == "RightHandIndex2"){
            //this connects the player with the right hand of the henchman who punches with his right hand
        }
    }
 
}

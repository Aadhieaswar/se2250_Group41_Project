    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaken : MonoBehaviour
{
    void OnCollisionEnter(Collision col){
        if(col.gameObject.name == "RightHandIndex2"){
            //add script for the decrease of the player health bar after merging
            //this connects the player with the right hand of the henchman who punches with his right hand
        }
    }
 
}

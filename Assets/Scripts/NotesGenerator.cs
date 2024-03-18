using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesGenerator : MonoBehaviour
{
    public GameObject notes;
    [SerializeField] int LaneNumber;
    
    public void CreateNotes(){
        if(LaneNumber == 0){
            Instantiate(notes,new Vector3(-1.5f,0.06f,11f),Quaternion.identity);
        }else if(LaneNumber == 1){
            Instantiate(notes,new Vector3(-0.5f,0.06f,11f),Quaternion.identity);
        }else if(LaneNumber == 2){
            Instantiate(notes,new Vector3(0.5f,0.06f,11f),Quaternion.identity);
        }else{
            Instantiate(notes,new Vector3(1.5f,0.06f,11f),Quaternion.identity);
        }
    }
}
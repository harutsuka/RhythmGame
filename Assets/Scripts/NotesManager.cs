using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesManager : MonoBehaviour
{
    public GameObject notes;
    
    public void CreateNotes(){
        Instantiate(notes,new Vector3(0.5f,0.12f,11f),Quaternion.identity);
    }
}
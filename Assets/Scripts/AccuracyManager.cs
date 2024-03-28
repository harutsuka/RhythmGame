using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AccuracyManager : MonoBehaviour
{
    public int score = 0;
    public Text AccuracyText;
    public List<GameObject> NotesList  = new List<GameObject>();
    
    public KeyCode keyName;
    public Transform limitTransform;

    public float perfectTime = 0.3f;
    public float greatTime = 0.5f;
    public float goodTime = 0.8f;
    public float badTime = 1f;

    void Update(){
        if(NotesList.Count == 0)return;
        var limitDist = Vector3.Distance(limitTransform.position,NotesList[0].transform.position);
        if(limitDist <= 0.1f){
            Debug.Log("miss");
            NotesList.RemoveAt(0);
        }

        if(Input.GetKey(keyName)){
            CheckTiming();
        }

        
    }

    void RemoveNote(){
        if(NotesList.Count > 0){
            NotesList.Remove(NotesList[0]);
        }
    }

    void CheckTiming(){
        GameObject currentNote = NotesList[0];
        float distance = Mathf.Abs(currentNote.transform.position.z - transform.position.z);
        if(distance < 2){
        if(distance > badTime){
          AccuracyText.text = "MISS!"; 
        }

        if(distance < perfectTime){
            AccuracyText.text = "PERFECT!";
            Debug.Log("per");
            score += 100;
        }else if(distance < greatTime){
            AccuracyText.text = "GREAT!";
            Debug.Log("gre");
            score += 80;
        }else if(distance < goodTime){
            AccuracyText.text = "GOOD!";
            Debug.Log("go");
            score += 50;
        }else if(distance < badTime){
            AccuracyText.text = "BAD";
            Debug.Log("bad");
            score += 30;
        }
        
        RemoveNote();
        }
    }
   
}

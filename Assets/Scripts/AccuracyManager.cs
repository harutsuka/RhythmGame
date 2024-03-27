using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class AccuracyManager : MonoBehaviour
{
    public Text AccuracyText;
    public List<GameObject> NotesList  = new List<GameObject>();
    
    public GameObject judgeLine;

    public float perfectTime = 0.5f;
    public float greatTime = 1f;
    public float goodTime = 1.5f;
    public float badTime = 2f;

    // 判定ポイントの真上に来る秒数
    private float reachTime = 4;

    void Update(){
        float distance = Vector3.Distance(NotesList[0].gameObject.transform.position,judgeLine.transform.position);
        if(distance <  -3){
          AccuracyText.text = "Miss!"; 
          Debug.Log("miss");
          RemoveList();
        }
        if(distance < perfectTime && distance > -perfectTime){
            Debug.Log("perfext");
            AccuracyText.text = "Perfect!";
            RemoveList();
        }else if(distance < greatTime &&  distance > -greatTime){
            Debug.Log("great");
            AccuracyText.text = "Great!";
            RemoveList();
        }else if(distance < goodTime && distance > -goodTime){
            AccuracyText.text = "Good!";
            Debug.Log("good");
            RemoveList();
        }else if(distance < badTime && distance > -badTime){
            AccuracyText.text = "Bad";
            Debug.Log("bad");
            RemoveList();
        }
    }

    void RemoveList(){
        NotesList.Remove(NotesList[0]);
    }
   
}

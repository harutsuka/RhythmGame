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
    public int combo = 0;
    public Text AccuracyText;
    public List<GameObject> NotesList  = new List<GameObject>();
    
    [SerializeField] KeyCode keyName;
    public Transform limitTransform;

    public float perfectTime = 0.2f;
    public float greatTime = 0.4f;
    public float goodTime = 0.5f;
    public float badTime = 0.8f;

    void Update(){
        if(NotesList.Count == 0)return;
        var limitDist = Vector3.Distance(limitTransform.position,NotesList[0].transform.position);
        if(limitDist <= 0.1f){
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
        if(distance < 1){
            if(distance > badTime){
                AccuracyText.text = "MISS!"; 

                Debug.Log("miss");
                combo = 0;
            }

            if(distance < perfectTime){
                AccuracyText.text = "PERFECT!";
                score += 100;

            }else if(distance < greatTime){
                AccuracyText.text = "GREAT!";
                score += 80;

            }else if(distance < goodTime){
                AccuracyText.text = "GOOD!";
                score += 50;

            }else if(distance < badTime){
                AccuracyText.text = "BAD";
                score += 30;

                combo = 0;
            }
        
            RemoveNote();
        }
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Note")){
            combo++;
            Debug.Log(combo);
        }
    }  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccuracyManager : MonoBehaviour
{
    public GameObject judgeLine;
    public GameObject note;
    
    public Text accuracyText;
    public float perfectTiming = 0.1f;
    public float greatTiming = 0.2f;
    public float goodTiming = 0.3f;
    public float badTiming = 0.5f;
      
    void Update()
    {
        float position = note.transform.position.z;
        if(Input.GetKeyDown(KeyCode.D) && Mathf.RoundToInt(position) == 0){
            CheckTiming(position);
        }
        if(Input.GetKeyDown(KeyCode.F) && Mathf.RoundToInt(position) == 0){
            CheckTiming(position);
        }
        if(Input.GetKeyDown(KeyCode.J) && Mathf.RoundToInt(position) == 0){
            CheckTiming(position);
        }
        if(Input.GetKeyDown(KeyCode.K) && Mathf.RoundToInt(position) == 0){
            CheckTiming(position);
        }

        if(position < -0.5f){
            accuracyText.text = "Miss";
        }
    }
    void CheckTiming(float position){
        float playerPosition = 0f;
        float timingDifference = Mathf.Abs(position - playerPosition);

        if(timingDifference <= perfectTiming){
            accuracyText.text = "Perfect!";
        }
        else if(timingDifference <= greatTiming){
            accuracyText.text = "Great!";
        }
        else if(timingDifference <= goodTiming){
            accuracyText.text = "Good";
        }
        else if(timingDifference <= badTiming){
            accuracyText.text = "Bad";
        }
        else accuracyText.text = "Miss";        

        Destroy(note);
        Debug.Log(accuracyText.text);
    }
}

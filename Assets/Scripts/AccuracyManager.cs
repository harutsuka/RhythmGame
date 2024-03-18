using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccuracyManager : MonoBehaviour
{
    public GameObject judgeLine;
    public GameObject note;
    public Vector3 accuracyPosition = new Vector3(0,-0.4f,0.8f);
    public Quaternion rotate = Quaternion.Euler(76, -0.5f, 0);

    public Text perfectText;
    public Text greatText;
    public Text goodText;
    public Text badText;
    public Text missText;
    public float perfectTiming = 0.1f;
    public float greatTiming = 0.2f;
    public float goodTiming = 0.3f;
    public float badTiming = 0.5f;
    
    void Update()
    {
        float position = transform.position.z;
        if(Input.GetKeyDown(KeyCode.D) && Mathf.RoundToInt(position) == 0){
            CheckTiming(position);
        }
        if(Input.GetKeyDown(KeyCode.F) && Mathf.RoundToInt(position) == 0){
            CheckTiming(position);
        }
        if(Input.GetKeyDown(KeyCode.J) && Mathf.RoundToInt(position) == 0){
            CheckTiming(position);
        }
        if(Input.GetKeyDown(KeyCode.J) && Mathf.RoundToInt(position) == 0){
            CheckTiming(position);
        }
    }
    void CheckTiming(float position){
        float playerPosition = 0f;
        float timingDifference = Mathf.Abs(position - playerPosition);

        if(timingDifference <= perfectTiming) Debug.Log("Perfect");
        else if(timingDifference <= greatTiming) Debug.Log("Great");
        else if(timingDifference <= goodTiming) Debug.Log("Good");
        else if(timingDifference <= badTiming) Debug.Log("Bad");
        else Debug.Log("Miss!");

        Destroy(gameObject);
    }
}

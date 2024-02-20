using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
    public float noteSpeed = 5f;
    public int score;

    public float perfectTiming = 0.1f;
    public float greatTiming = 0.2f;
    public float goodTiming = 0.3f;
    public float badTiming = 0.5f;

    void Update()
    {
        transform.Translate(0,0, -Time.deltaTime * noteSpeed);

        float position = transform.position.z;
        if(Input.GetKeyDown(KeyCode.J) && Mathf.RoundToInt(position) == 0){
            float playerPosition = 0f;
            float timingDifference = Mathf.Abs(position - playerPosition);
            
            if (timingDifference <= perfectTiming)
            {
                Debug.Log("Perfect");
                score += 200;
            }
            else if (timingDifference <= greatTiming)
            {
                Debug.Log("Great");
                score += 150;
            }
            else if (timingDifference <= goodTiming)
            {
                Debug.Log("Good");
                score += 100;
            }
            else if (timingDifference <= badTiming)
            {
                Debug.Log("Bad");
                score += 50;
            }
            else Debug.Log("Miss");
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public float noteSpeed = 5f;
    public int score;
    void Update()
    {
        transform.Translate(0,0, -Time.deltaTime * noteSpeed);

        float position = transform.position.z;
        if(Input.GetKeyDown(KeyCode.J) && Mathf.RoundToInt(position) == 0){
            Destroy(gameObject);
        }

        if(transform.position.z < -1.5f){
            Destroy(gameObject);
        }
    }
}

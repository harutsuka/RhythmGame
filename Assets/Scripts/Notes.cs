using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public float NoteSpeed = 5f;
    void Update()
    {
        transform.Translate(0,0, -Time.deltaTime * NoteSpeed);

        if(Input.GetKeyDown(KeyCode.J) && transform.position.z == 0){
            Destroy(gameObject);
            Debug.Log(88);
        }
        if(transform.position.z < -1.5f){
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Notes : MonoBehaviour
{
    public float noteSpeed = 5f;

    void Start(){
        
    }
    void Update()
    {
        transform.Translate(0,0, -Time.deltaTime * noteSpeed);

        if(gameObject.transform.position.z < -1.5f){
            Destroy(gameObject);
        }
    }
    
}

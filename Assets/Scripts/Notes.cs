using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Notes : MonoBehaviour
{
    public float noteSpeed = 5f;

    void Update()
    {
        transform.Translate(0,0, -Time.deltaTime * noteSpeed);
    }
    
}

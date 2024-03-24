using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    public Notes Notes;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0.99f,0.01f,11);
    }

    // Update is called once per frame
    void Update()
    {
        float noteSpeed = Notes.noteSpeed;
        transform.Translate(0,0, -Time.deltaTime * noteSpeed);
    }
}

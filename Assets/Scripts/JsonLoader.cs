using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonLoader : MonoBehaviour
{
    public TextAsset textAsset;
    public GameObject notes;
    // Start is called before the first frame update
    void Start()
    {
       LoadChart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadChart(){
        string jsonText = textAsset.ToString();
        JsonNode json = JsonNode.Parse(jsonText);
        
        foreach(JsonNode note in json["notes"]){
            string name = note["name"].Get<string>();
            string timeText = note["time"].Get<string>();
            float time = float.Parse(timeText);
            string durationText = note["duration"].Get<string>();
            float duration = float.Parse(durationText);
            
            if(name == "C4"){
                Invoke("GenerateC4Note",time);
            }else if (name == "D4") {
                Invoke("GenerateD4Note", time);
            }else if(name == "E4"){
                Invoke("GenerateE4Note",time);
            }else if(name == "F4")
            {
                Invoke("GenerateF4Note",time);
            }           
            if(duration > 0.315){
                float endTime = time + duration;
                if(name == "C4"){
                    Invoke("GenerateC4Note",endTime);
                }else if (name == "D4") {
                    Invoke("GenerateD4Note", endTime);
                }else if(name == "E4"){
                    Invoke("GenerateE4Note",endTime);
                }else if(name == "F4")
                {
                    Invoke("GenerateF4Note",endTime);
                }      
            }
        }
        
    }
    void GenerateC4Note(){
        GenerateNote("C4");
    }
    void GenerateD4Note(){
        GenerateNote("D4");
    }
    void GenerateE4Note(){
        GenerateNote("E4");
    }
    void GenerateF4Note(){
        GenerateNote("F4");
    }
    
    void GenerateNote(string name){
        Vector3 position = Vector3.zero; 

        if(name == "C4"){
            position = new Vector3(-1.5f, 0.06f, 11f);
        }else if(name == "D4"){
            position = new Vector3(-0.5f, 0.06f, 11f);
        }else if(name == "E4"){
            position = new Vector3(0.5f,0.06f,11f);
        }else if(name == "F4"){
            position = new Vector3(1.5f,0.06f,11f);
        }
        Instantiate(notes,position,Quaternion.identity);
    }
}

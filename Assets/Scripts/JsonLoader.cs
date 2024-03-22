using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonLoader : MonoBehaviour
{
    public TextAsset textAsset;
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

            if(name == "C3"){
                Invoke("GenerateNote",time);
            }
        }

        
    }
    void GenerateNote(){
        
    }
}

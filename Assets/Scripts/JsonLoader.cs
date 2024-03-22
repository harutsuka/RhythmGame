using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonLoader : MonoBehaviour
{
    public TextAsset textAsset;
    // Start is called before the first frame update
    void Start()
    {
        string jsonText = textAsset.ToString();
        JsonNode json = JsonNode.Parse(jsonText);
        
        foreach(JsonNode note in json["notes"]){
            string name = note["name"].Get<string>();
            float time = note["time"].Get<float>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}

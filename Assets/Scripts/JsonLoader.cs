using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JsonLoader : MonoBehaviour
{
    public float delayTime = 2.5f;
    public TextAsset textAsset;
    public GameObject notes;

     public Material material;
     public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
       LoadChart();
       GameStart();
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
                    Invoke("GenerateC4Mesh",time);
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
        
        GameStart();
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

    void GenerateC4Mesh(){
        
    }
    void GenerateMesh(string name){
        MeshFilter mf = GetComponent<MeshFilter>();
        MeshRenderer mr = GetComponent<MeshRenderer>();
 
        Vector3[] verts = new Vector3[4];
        int[] triangles = { 0, 1, 3, 1, 2, 3 };
 
        verts[0] = new Vector3(-1f, 0.06f, 11);
        verts[1] = new Vector3(0, 0.06f,11);
        verts[2] = new Vector3(0, 0.06f, 0);
        verts[3] = new Vector3(-1f, 0.06f, 0);
 
        Mesh mesh = new Mesh();
        mesh.vertices = verts;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
 
        mf.sharedMesh = mesh;
        mr.sharedMaterial = material;
    }

    void GameStart(){
        DOVirtual.DelayedCall(delayTime,() => {
            //audioSource.Play();
        });
    }
}

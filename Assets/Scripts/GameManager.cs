using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float delayTime = 2.5f;
    public TextAsset textAsset;
    public GameObject notes;

    public AudioSource audioSource;

    public GameObject longNotes;

    public AccuracyManager[] AccuracyManager;


    public Text scoreText;
    public int score;
    public int combo;
    public Text comboText;

    void Start()
    {
       LoadChart();
       GameStart();

       Application.targetFrameRate = 30;
    }

    void Update()
    {
        score = 0;
        for(var i =0;i<3;i++){
            score += AccuracyManager[i].score;
            combo += AccuracyManager[i].combo;

            if(combo < 1){
                comboText.text = "";
            }
        }
        scoreText.text = score.ToString();
        comboText.text = combo.ToString();
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
            if(duration > 0.5){
                float endTime = time + duration;
                float scale_factor = endTime - time;
                if(name == "C4"){
                    Invoke("GenerateC4Long",time);
                    Invoke("GenerateC4Note",endTime);
                    
                }else if (name == "D4") {
                    Invoke("GenerateD4Long",time);
                    Invoke("GenerateD4Note", endTime);
                }else if(name == "E4"){
                    Invoke("GenerateE4Long",time);
                    Invoke("GenerateE4Note",endTime);
                }else if(name == "F4")
                {
                    Invoke("GenerateF4Long",time);
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

        var note = Instantiate(notes,position,Quaternion.identity);

        if(name == "C4"){
            position = new Vector3(-1.5f, 0.06f, 11f);
            note.transform.position = position;
            AccuracyManager[0].NotesList.Add(note);
        }else if(name == "D4"){
            position = new Vector3(-0.5f, 0.06f, 11f);
            note.transform.position = position;
            AccuracyManager[1].NotesList.Add(note);
        }else if(name == "E4"){
            position = new Vector3(0.5f,0.06f,11f);
            note.transform.position = position;
            AccuracyManager[2].NotesList.Add(note);
        }else if(name == "F4"){
            position = new Vector3(1.5f,0.06f,11f);
            note.transform.position = position;
            AccuracyManager[3].NotesList.Add(note);
        }

        
        
    }

    void GenerateC4Long(){
        GenerateLongNote("C4");
    }
    void GenerateD4Long(){
        GenerateLongNote("D4");
    }
    void GenerateE4Long(){
        GenerateLongNote("E4");
    }
    void GenerateF4Long(){
        GenerateLongNote("F4");
    }
    void GenerateLongNote(string name){
        Vector3 position = Vector3.zero; 

        if(name == "C4"){
            position = new Vector3(-1.5f, 0.06f, 11f);
            //longNotes.transform.localScale = new Vector3();
        }else if(name == "D4"){
            position = new Vector3(-0.5f, 0.06f, 11f);
        }else if(name == "E4"){
            position = new Vector3(0.5f,0.06f,11f);
        }else if(name == "F4"){
            position = new Vector3(1.5f,0.06f,11f);
        }
        Instantiate(longNotes,position,Quaternion.identity);

    }

    void GameStart(){
        DOVirtual.DelayedCall(delayTime,() => {
            audioSource.Play();
        });

        float soundTime = 0;
        soundTime += Time.time;

        if(soundTime > audioSource.clip.length){
            SceneManager.LoadScene("Result");
            
        }
    }
}

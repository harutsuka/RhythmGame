using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameStartScript : MonoBehaviour
{
    [SerializeField] PlayableDirector director;
    void Start()
    {
       
    }

    void Update()
    {
        
    }
    void PlayTimeline(){
        director.Play();
    }
    public void GameStart(){
        SceneManager.LoadScene("Main");
    }
}

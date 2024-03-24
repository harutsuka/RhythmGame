using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    [SerializeField] private float Speed = 3f;
    [SerializeField] private int num = 0;
    private Renderer rend;
    private float alpha = 0;

    public SEManager SEManager;
    public AudioSource audioSource;
    public AudioClip laneSE;


    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {

        if (!(rend.material.color.a <= 0))
        {
            rend.material.color = new Color(rend.material.color.r, rend.material.color.r, rend.material.color.r, alpha);
        }

        if (num == 1)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                ColorChange();
                PlaySE();

            }
        }
        if (num == 2)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ColorChange();
                PlaySE();
            }
        }
        if (num == 3)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                ColorChange();
                PlaySE();
            }
        }
        if (num == 4)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                ColorChange();
                PlaySE();
            }
        }
        alpha -= Speed * Time.deltaTime;
    }

    void ColorChange()
    {
        alpha = 0.3f;
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, alpha);
    }

    void PlaySE(){
        bool isSeOn = SEManager.isSeOn;
        if(isSeOn){
            audioSource.PlayOneShot(laneSE);
        }
    }
}

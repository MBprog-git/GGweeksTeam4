using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Cinescen : MonoBehaviour
{
    // Start is called before the first frame update
   public VideoPlayer vd ;
    public float timer = 120; 
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;

        if (!vd.isPlaying && timer<0)
        {
            SceneManager.LoadScene("FinalScene");
        }
    }
}

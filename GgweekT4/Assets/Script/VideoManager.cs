using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoClip[] cinematique;
     Camera Cam;
    VideoPlayer vd;

    // Start is called before the first frame update
    void Start()
    {
      Cam =  GameManager.instance.Cam;
        vd = Cam.gameObject.GetComponent<VideoPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
            vd.clip = cinematique[0];
            vd.Play();
        }

        if (vd.isPlaying)
        {
            GameManager.instance.Player.GetComponent<PlayerController>().CanMove = false;
        }
        else
        {
            GameManager.instance.Player.GetComponent<PlayerController>().CanMove = true;

        }
    }
}

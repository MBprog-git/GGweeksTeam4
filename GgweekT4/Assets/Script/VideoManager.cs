using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoClip[] cinematique;
     Camera Cam;
    VideoPlayer vd;
    bool playing;
    // Start is called before the first frame update
    void Start()
    {
      Cam =  GameManager.instance.Cam;
        vd = Cam.gameObject.GetComponent<VideoPlayer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (playing)
        {
            if (vd.isPlaying)
            {
                GameManager.instance.Player.GetComponent<PlayerController>().CanMove = false;
            }
            else
            {
                GameManager.instance.Player.GetComponent<PlayerController>().CanMove = true;
                if (this.gameObject.GetComponent<Dialogue>() != null)
                {
                    this.gameObject.GetComponent<Dialogue>().StartDialogue();
                }
                playing = false;

            }
        }
    }

    public void PlayVideo(int video)
    {
        vd.clip = cinematique[video];
        vd.Play();
        playing = true;
    }
}

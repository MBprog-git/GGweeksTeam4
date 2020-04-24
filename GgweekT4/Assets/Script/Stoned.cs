using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoned : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.Cam.GetComponent<Caméra>().etourdis("On");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.Cam.GetComponent<Caméra>().etourdis("Off");
        }
    }
}

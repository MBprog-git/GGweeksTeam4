using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caméra : MonoBehaviour
{
    public FxPro SuperVision;
    public FxPro Etourdit;
    // Start is called before the first frame update
    void Start()
    {
        SuperVision.enabled = false;
        Etourdit.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void etourdis(string onOrOff) 
    {
        if (onOrOff == "On")
        {
            Etourdit.enabled = true;

        }

        if (onOrOff == "Off")
        {
            Etourdit.enabled = false;

        }



    }

    public void SeeThrougt() 
    {
        SuperVision.enabled = !SuperVision.isActiveAndEnabled;

    }
}

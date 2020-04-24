using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caméra : MonoBehaviour
{
    public FxPro SuperVision;
    public FxPro Etourdit;
    public bool etourdit = false;
    public bool super = false;
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
        if (onOrOff == "On" && !super)
        {
            Etourdit.enabled = true;
            etourdit = true;

        }

        if (onOrOff == "Off")
        {
            Etourdit.enabled = false;
            etourdit = false;
        }



    }

    public void SeeThrougt() 
    {
        if (!etourdit)
        {
            SuperVision.enabled = !SuperVision.isActiveAndEnabled;
            super = !super;
        }
        

    }
}

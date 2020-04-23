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

    public void etourdis() 
    {
        Etourdit.enabled = !Etourdit.isActiveAndEnabled;


    }

    public void SeeThrougt() 
    {
        SuperVision.enabled = !SuperVision.isActiveAndEnabled;

    }
}

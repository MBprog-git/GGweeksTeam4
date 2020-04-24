using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text Objectif;
    public Text Description;
    public Text Room_name;
    public Text ObjectToGet;
    public Text NbrObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "info")
        {
            Objectif.text = other.GetComponent<Info_Ui>().Objectif;
            Description.text = other.GetComponent<Info_Ui>().Objectif_Description;
            Room_name.text = other.GetComponent<Info_Ui>().Room;
            ObjectToGet.text = other.GetComponent<Info_Ui>().Object;



            NbrObject.text = "" + other.GetComponent<Info_Ui>().Nbr;
        }
        
    }
}

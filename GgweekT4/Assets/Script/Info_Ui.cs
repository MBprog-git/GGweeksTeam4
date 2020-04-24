using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info_Ui : MonoBehaviour
{
    public string Objectif;
    public string Object;
    public int Nbr;
    public string Room;
    public string Objectif_Description;
    public List<GameObject> nbrObject = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Nbr = nbrObject.Count;
    }

    public void Decount(int id)
    {
        for (int i = 0; i < nbrObject.Count; i++)
        {
            if (nbrObject[i].GetComponent<Items>().ID == id)
            {
                nbrObject.RemoveAt(i);
                break;
            }
        }

    }
}

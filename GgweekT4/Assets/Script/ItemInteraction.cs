using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public List<int> _Needed;
    public int IDAction;
    List<bool> verif= new List<bool>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
       
        for(int i=0; i<_Needed.Count; i++)
        {
            verif.Add(false);
        }
     

        for(int i=0; i<Inventaire.instance.Item.Length; i++)
        {
            if (Inventaire.instance.Item[i] != null)
            {

            
                 for(int j=0; j<_Needed.Count;j++)
                 {
                      if(_Needed[j] == Inventaire.instance.Item[i].GetComponent<Items>().ID)
                     {
                        verif[j] = true;
                     }
                 }
            }
        }
        bool action = true;
        for(int i=0; i < verif.Count; i++)
        {
            if (verif[i] == false)
            {
                action = false;
            }
        }

        if (action)
        {
            Action(IDAction);
        }

        verif.Clear();

    }

    public void Action(int idAct)
    {
        for (int i = 0; i < _Needed.Count; i++)
        {
            Inventaire.instance.ClearItems(_Needed[i]);
        }
        switch (idAct)
        {
            case 1:
                Debug.Log("Actionada");
                break;
        }
        
    }
}

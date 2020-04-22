using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventaire : MonoBehaviour
{
    public static Inventaire instance;
    public GameObject prefabHolder;
    private bool TurnOn = false;
    public GameObject inventaire;
    public GameObject[] Items_Holder;
    public GameObject[] Item;
   

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        inventaire.SetActive(TurnOn);
        for (int i = 0; i < 16; i++)
        {
            Items_Holder[i] = inventaire.transform.GetChild(i).gameObject;
        }
    }

    public void AddItems(GameObject ItemToAdd) 
    {
        for (int i = 0; i < Item.Length; i++)
        {
            if (Item[i] == null)
            {
                Item[i] = ItemToAdd;
                UpdateUi();
                break;
            }
        }
        
       
    
    }

    
    

    public void ClearItems(int id) 
    {
        for (int i = 0; i < Item.Length; i++)
        {
            if ( Item[i] != null && Item[i].GetComponent<Items>().ID == id)
            {
                Item[i] = null;
                UpdateUi();
                break;
            }
        }
         
    }

    



    void ShowUi() 
    {
        TurnOn = !TurnOn;
        inventaire.SetActive(TurnOn);
    
    }

    void UpdateUi() 
    {
        for (int i = 0; i < Item.Length; i++)
        {
            if (Item[i] != null)
            {
                switch (Item[i].GetComponent<Items>().ID)
                {


                    case 1:
                        Items_Holder[i].transform.GetChild(0).gameObject.SetActive(true);
                        Items_Holder[i].transform.GetChild(0).GetComponent<Image>().color = new Color32(0, 0, 0, 255);
                        break;

                    case 2:
                        Items_Holder[i].transform.GetChild(0).gameObject.SetActive(true);
                        Items_Holder[i].transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                        break;


                }
            }
            
            if (Item[i] == null)
            {
                Items_Holder[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ShowUi();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventaire : MonoBehaviour
{
    public static Inventaire instance;
    private bool TurnOn = false;
    public GameObject inventaire;
    public List<GameObject> Items_Holder = new List<GameObject>();

    public List<GameObject> Item = new List<GameObject>();
   

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
           Items_Holder.Add(inventaire.transform.GetChild(i).gameObject);
        }
    }

    public void AddItems(GameObject ItemToAdd) 
    {
        Item.Add(ItemToAdd);
        UpdateUi();
    
    }

    void ShowUi() 
    {
        TurnOn = !TurnOn;
        inventaire.SetActive(TurnOn);
    
    }

    void UpdateUi() 
    {
        for (int i = 0; i < Item.Count; i++)
        {
            switch (Item[i].GetComponent<Items>().ID)
            {
                case 1:
                    Items_Holder[i].transform.GetChild(0).gameObject.SetActive(true);
                    Items_Holder[i].transform.GetChild(0).GetComponent<Image>().color = new Color32(0, 0, 0,255);
                    break;
                
                case 2:
                    Items_Holder[i].transform.GetChild(0).gameObject.SetActive(true);
                    Items_Holder[i].transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 0, 0,255);
                    break;
            
            
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

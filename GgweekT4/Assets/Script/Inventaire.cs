using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventaire : MonoBehaviour
{
    public static Inventaire instance;
    
    private bool TurnOn = false;
    public List<Sprite> icon = new List<Sprite>();
    public GameObject inventaire;
    public GameObject[] Items_Holder;
    public GameObject[] Item;
   

    /* 1:Silex
     * 2: bois
     * 3:tissus
     * 
     * 5: amulette
     
     
         
         
         */








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
        GameManager.instance.Player.GetComponent<PlayerController>().CanMove = !GameManager.instance.Player.GetComponent<PlayerController>().CanMove;
        GameManager.instance.Cancam = !GameManager.instance.Cancam;
        TurnOn = !TurnOn;
        inventaire.SetActive(TurnOn);
    
    }

    void UpdateUi() 
    {
        for (int i = 0; i < Item.Length; i++)
        {
            if (Item[i] != null)
            {
                Items_Holder[i].transform.GetChild(0).gameObject.SetActive(true);
             
                        Items_Holder[i].transform.GetChild(0).GetComponent<Image>().sprite = icon[Item[i].GetComponent<Items>().ID];
                        

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

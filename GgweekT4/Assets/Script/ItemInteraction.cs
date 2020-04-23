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

        if (_Needed[0] == 100)
        {
            Action(IDAction);
            return;
        }

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
        if (_Needed[0] != 100)
        {
            for (int i = 0; i < _Needed.Count; i++)
            {
                Inventaire.instance.ClearItems(_Needed[i]);
            }
        }
        switch (idAct)
        {
            case 1:
                GameManager.instance.Player.GetComponent<Light>().enabled = true;
                this.gameObject.GetComponent<Dialogue>().StartDialogue();
                
                break;
            case 2:
                this.gameObject.SetActive(false);
                break;
            case 3:
                                 ///LIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIBRE
                    break;       
            case 4:
               this.gameObject.GetComponent<QTE>().StartQTE();
                    break;  
            case 5:
                GameManager.instance.Player.GetComponent<PlayerController>().CanJump = true;
                GameManager.instance.Player.GetComponent<PlayerController>().speed += GameManager.instance.Player.GetComponent<PlayerController>().speed;
                    break;
            case 6:
                this.gameObject.GetComponent<Dialogue>().StartDialogue();
                break;

            case 7:this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                GameManager.instance.Door.GetComponent<Animation>().Play(GameManager.instance.Door.GetComponent<Animation>().clip.name);
                this.gameObject.GetComponent<Dialogue>().StartDialogue();

                    break;
            case 8:
                GameManager.instance.gameObject.GetComponent<VideoManager>().PlayVideo(1);
                break;
            
        }
        
    }
}

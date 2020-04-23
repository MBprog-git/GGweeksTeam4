using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject box;
    public Text txt;
    public List<string> dialogues;
    int step;
    bool EnDialogue;
    public int IDaction;
    public bool played;
    public bool Voyeur;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EnDialogue && Input.GetKeyDown(KeyCode.Return))
        {
            
            if(step+1 == dialogues.Count)
            {
                EnDialogue = false;
                played = true;
                txt.text = "";
                txt.gameObject.SetActive(false);
                box.gameObject.SetActive(false);
                GameManager.instance.Cancam = true;
                GameManager.instance.Player.GetComponent<PlayerController>().CanMove = true;
                this.gameObject.GetComponent<ItemInteraction>().Action(IDaction);

            }
            else
            {
                step++;
                txt.text = dialogues[step];
            }
        }
    }
public void StartDialogue()
    {
        GameManager.instance.Cancam = false;
        GameManager.instance.Player.GetComponent<PlayerController>().CanMove = false;
        step = 0;
        box.SetActive(true);
        txt.gameObject.SetActive(true);
        EnDialogue = true;
        txt.text = dialogues[step];

    }
}

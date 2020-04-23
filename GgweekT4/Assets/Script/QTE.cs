using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE : MonoBehaviour
{
    public float Temps;
    float Timer;
  public int Idaction;  
    public int NombreStep;
    public GameObject bar;
        bool EnQTE;
    int step;
    KeyCode soluce;
   public  Text Indic;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
  

        if (EnQTE)
        {
            Timer -= Time.deltaTime;
            bar.transform.localScale = new Vector2(Timer, bar.transform.localScale.y);

            if (Timer < 0)
            {
                Debug.Log("QTE FAIL TIMER");
                EnQTE = false;
                bar.SetActive(false);
                Indic.gameObject.SetActive(false);
                GameManager.instance.Player.GetComponent<PlayerController>().CanMove = true;
                GameManager.instance.CanCam = true;
            }
            else if (Input.GetKeyDown(soluce))
            {
                if (step < NombreStep-1)
                {
                    step++;
                    StartRound();
                }
                else
                {
                    this.gameObject.GetComponent<ItemInteraction>().Action(Idaction);
                        EnQTE = false;
                        bar.SetActive(false);
                        Indic.gameObject.SetActive(false);
                        GameManager.instance.Player.GetComponent<PlayerController>().CanMove = true;
                    GameManager.instance.CanCam = true;
                }
            }/*else if (Input.anyKeyDown)
            {
                Debug.Log("QTE FAIL TOUCHE");
                    EnQTE = false;
                    bar.SetActive(false);
                Indic.gameObject.SetActive(false);
                  GameManager.instance.Player.GetComponent<PlayerController>().CanMove = true;
                
            }*/
        }
    }
    public void StartQTE()
    {
        if (EnQTE)
        {
            return;
        }
        Indic.gameObject.SetActive(true);
        Indic.text = "";
        step = 0;
        bar.SetActive(true);
        GameManager.instance.Player.GetComponent<PlayerController>().CanMove = false;
        GameManager.instance.CanCam = false;
        EnQTE = true;
        StartRound();
    }
    public void StartRound()
    {
         Timer = Temps;
        int i = Random.Range(0, 5);

        switch(i)
        {
            case 0:
                soluce = KeyCode.A;
                Indic.text = "A";
                break;  
            case 1:
                soluce = KeyCode.Z;
                Indic.text = "Z";
                break; 
            case 2:
                soluce = KeyCode.E;
                Indic.text = "E";
                break;  
            case 3:
                soluce = KeyCode.R;
                Indic.text = "R";
                break; 
            case 4:
                soluce = KeyCode.T;
                Indic.text = "T";
                break;
        }
    }
}

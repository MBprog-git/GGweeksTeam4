using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject command;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quitter() {

        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("FinalScene");
    }
    public void Option()
    {
        command.SetActive(true);
    }
    public void FermerOption()
    {
        command.SetActive (false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [Header("Déplacement")]
    
    public float speed;
    public float Gravity;
    public float FallSpeedMax;

   public float SpeedJump;
   
   public float SpeedJumpMin;
   public float TimeJump;

    [Space]
    [Header("Caméra")]
    public float SensitivityH;
    public float SensitivityV;
    public float OffsetX;
    public float OffsetY;
    public float OffsetZ;

    public float LimiteCamDown = -90;
    public float LimiteCamUp = 15;

    public float _speedSmooth;

    [Space]
   public  float _MaxDistance;
    
    [Space]
    [Header("Manager")]

    public Camera Cam;
    public GameObject Player;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    public GameObject RamasseFeedback;
    public GameObject Door;
    public GameObject BoxDialogue;
    public GameObject InfoUi1;
    public GameObject InfoUi2;
    public Text  TxtDialogue;
    public static GameManager instance;
    public float timedialogue;
    public bool Cancam = true;
    private Vector3 _velocity = Vector3.zero;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Dialogue>().StartDialogue();
        Cam.transform.position = new Vector3(Player.transform.position.x + OffsetX, Player.transform.position.y + OffsetY, Player.transform.position.z + OffsetZ);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {

            Cam.GetComponent<Caméra>().SeeThrougt();
            foreach(Items item in Resources.FindObjectsOfTypeAll(typeof(Items))) 
            {
                item.Shine();
            
            }
        }



        //Camera



        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Cancam)
        {
            yaw += SensitivityH * Input.GetAxis("Mouse X");
            pitch -= SensitivityV * Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, LimiteCamDown, LimiteCamUp);
            Cam.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
            Player.transform.eulerAngles = new Vector3(Player.transform.eulerAngles.x, yaw, Player.transform.eulerAngles.z);
            // Cam.transform.position = new Vector3(Player.transform.position.x + OffsetX, Player.transform.position.y + OffsetY, Player.transform.position.z + OffsetZ);
            
            Vector3 newPosCam = new Vector3(Player.transform.position.x + OffsetX, Player.transform.position.y + OffsetY, Player.transform.position.z + OffsetZ);
            newPosCam = Vector3.SmoothDamp(Cam.transform.position, newPosCam, ref _velocity, _speedSmooth);

        Cam.transform.position = new Vector3(newPosCam.x, newPosCam.y, newPosCam.z);
    }
        //Sélection & Interaction
            Vector3 Mouspos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(Mouspos, Cam.transform.TransformDirection(Vector3.forward), _MaxDistance);
       // Debug.DrawLine(Mouspos, Cam.transform.TransformDirection(Vector3.forward) * _MaxDistance, Color.red);
        bool ObjetPresent = false;
        foreach (RaycastHit hit in hits)
        {
            if  ( hit.collider.GetComponent<Items>()!= null || hit.collider.GetComponent<ItemInteraction>() != null)
            {
                ObjetPresent = true;
                
            }
            if (hit.collider.GetComponent<Dialogue>() != null && !hit.collider.GetComponent<Dialogue>().played && hit.collider.GetComponent<Dialogue>().Voyeur)
            {
                hit.collider.GetComponent<Dialogue>().StartDialogue();
            }
        }
            if (ObjetPresent)
            {
                RamasseFeedback.SetActive(true);

            }
            else
            {
                RamasseFeedback.SetActive(false);

            }


        if (Input.GetMouseButtonUp(0))
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.GetComponent<ItemInteraction>() != null)
                {
                    hit.collider.GetComponent<ItemInteraction>().Interact();
                    break;
                }
                if (hit.collider.GetComponent<Items>() != null && hit.collider.GetComponent<Items>().ID != 0)
                {
                    Inventaire.instance.AddItems(hit.collider.gameObject);
                    hit.collider.gameObject.SetActive(false);
                    break;
                }
                
            }
        }
    }
    public void doExitGame()
    {
        Application.Quit();
    }
    public void MyLoadScene(string nameScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
     
    }
}

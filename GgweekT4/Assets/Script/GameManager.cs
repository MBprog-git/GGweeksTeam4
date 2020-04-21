using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Déplacement")]
    public float speed;
public float Gravity;
public float FallSpeedMax;
    [Space]
    [Header("Caméra")]
    public float SensitivityH;
    public float SensitivityV;
    public float OffsetX;
    public float OffsetY;
    public float OffsetZ;

    public float LimiteCamDown = -90;
    public float LimiteCamUp = 15;

    [Space]
    [Header("Manager")]

    public static GameManager instance;
    public Camera Cam;
    public GameObject Player;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Camera
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        yaw += SensitivityH * Input.GetAxis("Mouse X");
        pitch -= SensitivityV * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, LimiteCamDown, LimiteCamUp);
        Cam.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        Player.transform.eulerAngles = new Vector3(Player.transform.eulerAngles.x, yaw, Player.transform.eulerAngles.z);
        Cam.transform.position = new Vector3(Player.transform.position.x + OffsetX, Player.transform.position.y + OffsetY, Player.transform.position.z + OffsetZ);
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

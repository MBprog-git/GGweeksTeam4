using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public Material surbrillance;
    public Material BaseM;
    private MeshRenderer Mesh;
    private bool ShinyOrNot = false;
    public int ID;
    // Start is called before the first frame update
    void Start()
    {
        Mesh = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Inventaire.instance.AddItems(this.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Inventaire.instance.ClearItems(ID);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ShinyOrNot = !ShinyOrNot;
            Shine();
        }
    }

    void Shine() 
    {
        if (ShinyOrNot)
        {
            Mesh.sharedMaterial = surbrillance;
        }
        if (!ShinyOrNot)
        {
            Mesh.sharedMaterial = BaseM;
        }
    
    
    }
}

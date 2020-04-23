using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExitDialgoue : MonoBehaviour
{
    bool once;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && !once)
        {
            once = true;
            this.gameObject.GetComponent<Dialogue>().StartDialogue();
        }
    }
}
